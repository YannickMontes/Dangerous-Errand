using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
	#region Private

	private void Update()
	{
		if (m_isActive)
		{
			foreach (GameObject shield in m_shields)
			{
				if (shield.activeInHierarchy)
				{
					return;
				}
			}

			SetActive(false);
		}
	}

	protected override void SetActive(bool active)
	{
		base.SetActive(active);
		if (m_isActive)
		{
			m_rotateEmmiter.gameObject.SetActive(true);
			m_rotateEmmiter.StartBehaviour();
		}
		else
		{
			m_rotateEmmiter.StopBehaviour();
			m_rotateEmmiter.gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

	[SerializeField]
	private RotateEmmiterHandler m_rotateEmmiter = null;
	[SerializeField]
	private List<GameObject> m_shields = new List<GameObject>();

	#endregion Private
}