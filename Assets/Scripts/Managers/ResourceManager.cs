using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	public static ResourceManager Instance { get { return s_instance; } }

	public T AcquireInstance<T>(T prefab, Transform parent, bool active = true) where T : MonoBehaviour
	{
		GameObject obj = AcquireInstance(prefab.gameObject, parent, active);
		T instance = obj.GetComponent<T>();
		if (instance == null)
		{
			Debug.LogError("Can't acquire instance, no required MonoBehaviour on prefab.");
		}
		return instance;
	}

	public GameObject AcquireInstance(GameObject prefab, Transform parent, bool active = true)
	{
		GameObject instance = null;
		if (m_pooledObjects[prefab].Count == 0)
		{
			instance = GameObject.Instantiate(prefab, parent);
		}
		else
		{
			instance = m_pooledObjects[prefab].Dequeue();
		}
		instance.SetActive(active);
		m_usedObjects.Add(new PooledObject(prefab, instance));
		return instance;
	}

	public void ReleaseInstance(GameObject instance)
	{
		instance.SetActive(false);
		instance.transform.SetParent(transform);
		GameObject prefab = null;
		foreach (PooledObject pooledObj in m_usedObjects)
		{
			if (pooledObj.Object == instance)
			{
				prefab = pooledObj.Prefab;
				break;
			}
		}
		if (!m_pooledObjects.ContainsKey(prefab))
		{
			Destroy(instance);
		}
		else
		{
			m_pooledObjects[prefab].Enqueue(instance);
		}
	}

	#region Private

	[Serializable]
	private class ObjectToPool
	{
		public GameObject Prefab = null;
		public int Size = 5;
	}

	private struct PooledObject
	{
		public PooledObject(GameObject prefab, GameObject instance)
		{
			Object = instance;
			Prefab = prefab;
		}

		public GameObject Object;
		public GameObject Prefab;
	}

	private void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
			Init();
		}
		else
		{
			Debug.LogError("Multiple ResourceManager found. Destroy this one", gameObject);
		}
	}

	private void Init()
	{
		m_usedObjects = new List<PooledObject>();
		m_pooledObjects = new Dictionary<GameObject, Queue<GameObject>>();
		foreach (ObjectToPool objToPool in m_objectsToPool)
		{
			Queue<GameObject> pooledObj = new Queue<GameObject>();
			for (int i = 0; i < objToPool.Size; i++)
			{
				GameObject instance = GameObject.Instantiate(objToPool.Prefab, transform);
				instance.SetActive(false);
				pooledObj.Enqueue(instance);
			}
			m_pooledObjects[objToPool.Prefab] = pooledObj;
		}
	}

	[SerializeField]
	private List<ObjectToPool> m_objectsToPool = new List<ObjectToPool>();

	[NonSerialized]
	private static ResourceManager s_instance = null;

	[NonSerialized]
	private Dictionary<GameObject, Queue<GameObject>> m_pooledObjects = null;

	[NonSerialized]
	private List<PooledObject> m_usedObjects = null;

	#endregion Private
}