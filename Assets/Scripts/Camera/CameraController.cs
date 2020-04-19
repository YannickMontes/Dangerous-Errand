using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public static CameraController Instance { get { return s_instance; } }

	public void StartTravelling()
	{
		m_currentSpeed = m_defaultSpeed;
	}

	public void StopTravelling()
	{
		m_currentSpeed = 0.0f;
	}

	public void IncreaseTravellingSpeed(float increase)
	{
		m_currentSpeed += increase;
	}

	#region Private

	private void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		m_currentSpeed = m_defaultSpeed;
	}

	private void FixedUpdate()
	{
		transform.Translate(new Vector2(0.0f, m_currentSpeed));
	}

	[SerializeField]
	private float m_defaultSpeed = 0.05f;

	[NonSerialized]
	private float m_currentSpeed = 0.0f;

	private static CameraController s_instance = null;

	#endregion Private
}