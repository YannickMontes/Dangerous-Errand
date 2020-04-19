using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIncreaseSpeedPoint : CameraControlPoint
{
	protected override void OnPlayerEnter()
	{
		CameraController.Instance.IncreaseTravellingSpeed(m_increaseValue);
	}

	[SerializeField]
	private float m_increaseValue = 2.0f;
}