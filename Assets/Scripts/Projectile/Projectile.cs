using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int ContaminationValue { get { return m_contaminationValue; } }

	#region Private

	private void Awake()
	{
		m_audioSource = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		m_isReleased = false;
		Invoke("ReleaseProjectile", m_lifeTime);
		PlaySound();
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
		if (collision.tag == "ProjectilesBox")
		{
			ReleaseProjectile();
		}
	}

	protected void ReleaseProjectile()
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

	protected void PlaySound()
	{
		m_audioSource.Play();
	}

	[SerializeField]
	private float m_speed = 1.0f;
	[SerializeField]
	protected int m_contaminationValue = 2;
	[SerializeField]
	private float m_lifeTime = 5.0f;
	[NonSerialized]
	private AudioSource m_audioSource = null;
	[NonSerialized]
	private Vector3 m_direction = Vector2.up;
	[NonSerialized]
	private bool m_isReleased = true;

	#endregion Private
}