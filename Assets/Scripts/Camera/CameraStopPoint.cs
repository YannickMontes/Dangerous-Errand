using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStopPoint : CameraControlPoint
{
	protected override void OnCameraEnter()
	{
		CameraController.Instance.StopTravelling();
	}
}