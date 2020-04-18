using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
	public new EnemyAsset Asset { get { return base.Asset as EnemyAsset; } }

	public void DecreaseContamination(int value)
	{
		m_contamination -= value;
	}
}