using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartPoint : CameraControlPoint
{
	protected override void OnCameraEnter()
	{
		CameraController.Instance.StartTravelling();
	}
}