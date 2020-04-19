﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	public new PlayerAsset Asset { get { return base.Asset as PlayerAsset; } }

	public void IncreaseContamination(int value)
	{
		m_contamination += value;
	}

	#region Private

	protected override void Start()
	{
		InputManager.Instance.RegisterOnInputAxis(Asset.HorizontalInputType, OnAxisInput, true);
		InputManager.Instance.RegisterOnInputAxis(Asset.VerticalInputType, OnAxisInput, true);
		InputManager.Instance.RegisterOnShootButtonDown(OnShootButtonDown, true);
	}

	protected override void OnDestroy()
	{
		InputManager.Instance.RegisterOnInputAxis(Asset.HorizontalInputType, OnAxisInput, false);
		InputManager.Instance.RegisterOnInputAxis(Asset.VerticalInputType, OnAxisInput, false);
		InputManager.Instance.RegisterOnShootButtonDown(OnShootButtonDown, false);
	}

	private void OnAxisInput(InputManager.InputAxisType inputType, float value)
	{
		if (inputType == Asset.HorizontalInputType)
		{
			m_horizontalSpeed = value * Asset.Speed;
		}
		else if (inputType == Asset.VerticalInputType)
		{
			m_verticalSpeed = value * Asset.Speed;
		}

		if ((m_verticalSpeed < 0 && IsCollidingBorder("Bot"))
			|| (m_verticalSpeed > 0 && IsCollidingBorder("Top")))
		{
			m_verticalSpeed = 0.0f;
		}
		if ((m_horizontalSpeed < 0 && IsCollidingBorder("Left"))
			|| (m_horizontalSpeed > 0 && IsCollidingBorder("Right")))
		{
			m_horizontalSpeed = 0.0f;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag.Contains("Border"))
		{
			m_borderColliding.Add(collision.gameObject);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.tag.Contains("Border"))
		{
			m_borderColliding.Remove(collision.gameObject);
		}
	}

	private void OnShootButtonDown()
	{
		if (m_canShoot)
		{
			Projectile projectile = ResourceManager.Instance.AcquireInstance(Asset.DefaultProjectile, transform);
			projectile.transform.SetParent(null);
			m_canShoot = false;
			StartCoroutine(WaitCanShoot());
		}
	}

	private void FixedUpdate()
	{
		if (m_horizontalSpeed != 0 || m_verticalSpeed != 0)
		{
			transform.Translate(new Vector2(m_horizontalSpeed, m_verticalSpeed));
		}
	}

	private IEnumerator WaitCanShoot()
	{
		yield return new WaitForSeconds(Asset.TimeBetweenShoot);
		m_canShoot = true;
	}

	private bool IsCollidingBorder(string borderType)
	{
		foreach (GameObject border in m_borderColliding)
		{
			if (border.tag == $"{borderType}Border")
			{
				return true;
			}
		}
		return false;
	}

	[NonSerialized]
	private float m_horizontalSpeed = 0.0f;

	[NonSerialized]
	private float m_verticalSpeed = 0.0f;

	[NonSerialized]
	private bool m_canShoot = true;
	[NonSerialized]
	private List<GameObject> m_borderColliding = new List<GameObject>();

	#endregion Private
}