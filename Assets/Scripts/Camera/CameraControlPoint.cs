using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraControlPoint : MonoBehaviour
{
	#region Private

	protected abstract void OnPlayerEnter();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!m_hasTrigger && collision.tag == "Player")
		{
			OnPlayerEnter();
			m_hasTrigger = true;
		}
	}

	[NonSerialized]
	private bool m_hasTrigger = false;

	#endregion Private
}