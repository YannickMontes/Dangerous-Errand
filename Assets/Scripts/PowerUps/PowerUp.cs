using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
	public int PickUpScore { get { return m_pickUpScore; } }

	public virtual void StartPowerUp(Player player)
	{
		SetActive(true);
	}

	#region Private

	protected virtual void SetActive(bool active)
	{
		m_isActive = active;
		m_groundPowerUpVisual.SetActive(!m_isActive);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.GetComponent<Player>().CollectPowerUp(this);
		}
	}

	[SerializeField]
	private GameObject m_groundPowerUpVisual = null;
	[SerializeField]
	private int m_pickUpScore = 10;

	[NonSerialized]
	protected bool m_isActive = false;

	#endregion Private
}