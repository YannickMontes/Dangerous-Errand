using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraControlPoint : MonoBehaviour
{
	public void Apply()
	{
		if (!m_alreadyApplied)
		{
			m_alreadyApplied = true;
			OnCameraEnter();
		}
	}

	#region Private

	protected abstract void OnCameraEnter();

	[NonSerialized]
	private bool m_alreadyApplied = false;

	#endregion Private
}