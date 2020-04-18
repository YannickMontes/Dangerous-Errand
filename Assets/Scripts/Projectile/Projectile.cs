using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int ContaminationValue { get { return m_contaminationValue; } }

	public static Projectile AcquireInstance(Projectile prefab, Transform parent, Vector3 position
		, Vector3 direction)
	{
		Projectile proj = ResourceManager.Instance.AcquireInstance(prefab, parent);
		proj.transform.position = position;
		proj.m_direction = direction;
		return proj;
	}

	#region Private

	private void FixedUpdate()
	{
		transform.Translate(m_direction * m_speed);
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Border")
		{
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
	}

	[SerializeField]
	private float m_speed = 1.0f;

	[SerializeField]
	protected int m_contaminationValue = 2;

	[NonSerialized]
	private Vector3 m_direction = Vector2.up;

	#endregion Private
}