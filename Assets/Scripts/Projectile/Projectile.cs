using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int ContaminationValue { get { return m_contaminationValue; } }

	public AudioClip GetRandomAudioClip()
	{
		return m_sounds.Count > 0 ? m_sounds[UnityEngine.Random.Range(0, m_sounds.Count)] : null;
	}

	public void ReleaseProjectile()
	{
		if (!m_isReleased)
		{
			m_isReleased = true;
			if (gameObject.activeInHierarchy)
			{
				ResourceManager.Instance.ReleaseInstance(gameObject);
			}
		}
	}

	#region Private

	private void Awake()
	{
		m_collider = GetComponent<BoxCollider2D>();
	}

	private void OnEnable()
	{
		m_isReleased = false;
		Invoke("ReleaseProjectile", m_lifeTime);
	}

	private void OnDisable()
	{
		CancelInvoke();
	}

	private void FixedUpdate()
	{
		transform.Translate(Vector3.up * m_speed);
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
	}

	protected virtual void OnTriggerExit2D(Collider2D collision)
	{
		if (!gameObject.activeInHierarchy)
			return;
		if (collision.tag == "ProjectilesBox")
		{
			ReleaseProjectile();
		}
	}

	[SerializeField]
	private float m_speed = 1.0f;
	[SerializeField]
	protected int m_contaminationValue = 2;
	[SerializeField]
	private float m_lifeTime = 5.0f;
	[SerializeField]
	private List<AudioClip> m_sounds = new List<AudioClip>();

	[NonSerialized]
	private Vector3 m_direction = Vector2.up;
	[NonSerialized]
	private bool m_isReleased = true;
	[NonSerialized]
	protected BoxCollider2D m_collider = null;

	#endregion Private
}