﻿using System;
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

	private void Start()
	{
		GameManager.Instance.RegisterStateListener(OnGameManagerStateChanged, true);
	}

	private void OnGameManagerStateChanged(GameManager.State state)
	{
		if (state != GameManager.State.DEFAULT)
		{
			m_currentSpeed = 0.0f;
		}
	}

	private void OnDestroy()
	{
		GameManager.Instance?.RegisterStateListener(OnGameManagerStateChanged, false);
	}

	private void FixedUpdate()
	{
		transform.Translate(new Vector2(0.0f, m_currentSpeed));
	}

	private void Update()
	{
		if (m_currentSpeed != 0)
		{
			Debug.DrawLine(transform.position, transform.position + (Vector3.forward * 5), Color.red, 2.0f);
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, 15.0f, m_camControlMask);
			if (hit.collider != null)
			{
				hit.collider.gameObject.GetComponent<CameraControlPoint>().Apply();
			}
		}
	}

	[SerializeField]
	private float m_defaultSpeed = 0.05f;
	[SerializeField]
	private LayerMask m_camControlMask = 0;

	[NonSerialized]
	private float m_currentSpeed = 0.0f;

	private static CameraController s_instance = null;

	#endregion Private
}