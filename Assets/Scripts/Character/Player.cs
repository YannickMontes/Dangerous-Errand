using System;
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

	private void Start()
	{
		InputManager.Instance.RegisterOnInputAxis(Asset.HorizontalInputType, OnAxisInput, true);
		InputManager.Instance.RegisterOnInputAxis(Asset.VerticalInputType, OnAxisInput, true);
		InputManager.Instance.RegisterOnShootButtonDown(OnShootButtonDown, true);
	}

	private void OnDestroy()
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
	}

	private void OnShootButtonDown()
	{
		Projectile projectile = Projectile.AcquireInstance(Asset.DefaultProjectile, null, transform.position, Vector2.up);
	}

	private void FixedUpdate()
	{
		if (m_horizontalSpeed != 0 || m_verticalSpeed != 0)
		{
			transform.Translate(new Vector2(m_horizontalSpeed, m_verticalSpeed));
		}
	}

	[NonSerialized]
	private float m_horizontalSpeed = 0.0f;

	[NonSerialized]
	private float m_verticalSpeed = 0.0f;

	#endregion Private
}