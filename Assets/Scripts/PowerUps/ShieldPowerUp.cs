using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
	public override void StartPowerUp(Player player)
	{
		SetActive(true);
	}

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

	private void SetActive(bool active)
	{
		m_isActive = active;
		if (m_isActive)
		{
			m_groundPowerUpVisual.SetActive(false);
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
	private GameObject m_groundPowerUpVisual = null;
	[SerializeField]
	private RotateEmmiterHandler m_rotateEmmiter = null;
	[SerializeField]
	private List<GameObject> m_shields = new List<GameObject>();

	[NonSerialized]
	private bool m_isActive = false;

	#endregion Private
}