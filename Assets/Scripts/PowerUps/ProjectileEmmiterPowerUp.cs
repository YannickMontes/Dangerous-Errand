using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmmiterPowerUp : PowerUp
{
	public IReadOnlyList<Emmiter> Emmiters { get { return m_emmiterHandler.Emitters; } }

	public override void StartPowerUp(Player player)
	{
		base.StartPowerUp(player);
		if (m_activeTime != -1)
		{
			Invoke("DisablePowerUp", m_activeTime);
		}
	}

	#region Private

	protected override void SetActive(bool active)
	{
		base.SetActive(active);
		m_emmiterHandler.gameObject.SetActive(m_isActive);
	}

	private void OnDestroy()
	{
		CancelInvoke();
	}

	private void DisablePowerUp()
	{
		m_associatedPlayer.RemovePowerUp(this);
		Destroy(gameObject);
	}

	[SerializeField]
	private float m_activeTime = -1;

	[SerializeField]
	private EmmiterHandler m_emmiterHandler = null;

	[NonSerialized]
	private Player m_associatedPlayer = null;

	#endregion Private
}