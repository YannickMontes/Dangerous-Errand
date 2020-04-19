using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EmmiterHandler : MonoBehaviour
{
	public IReadOnlyList<GameObject> Emitters { get { return m_emitters; } }
	public Projectile ProjectilePrefab { get { return m_projectilePrefab; } }

	public virtual void StartBehaviour()
	{
		m_isStarted = true;
	}

	public virtual void StopBehaviour()
	{
		m_isStarted = false;
	}

	#region Private

	private void OnEnable()
	{
		StartBehaviour();
	}

	private void OnDisable()
	{
		StopBehaviour();
	}

	private void FixedUpdate()
	{
		if (m_isStarted)
		{
			DoTreatment();
		}
	}

	protected abstract void DoTreatment();

	[SerializeField]
	private List<GameObject> m_emitters = new List<GameObject>();
	[SerializeField]
	private Projectile m_projectilePrefab = null;
	[SerializeField]
	protected Transform m_emmiterParent = null;

	[NonSerialized]
	private bool m_isStarted = false;

	#endregion Private
}