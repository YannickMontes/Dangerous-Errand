using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int ContaminationValue { get { return m_contaminationValue; } }

	#region Private

	private void OnEnable()
	{
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
		if (collision.tag.Contains("Border"))
		{
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
	}

	private void ReleaseProjectile()
	{
		if (gameObject.activeInHierarchy)
		{
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
	}

	[SerializeField]
	private float m_speed = 1.0f;
	[SerializeField]
	protected int m_contaminationValue = 2;
	[SerializeField]
	private float m_lifeTime = 5.0f;
	[NonSerialized]
	private Vector3 m_direction = Vector2.up;

	#endregion Private
}