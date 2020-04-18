using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	#region Private

	private void Awake()
	{
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

	#endregion Private
}