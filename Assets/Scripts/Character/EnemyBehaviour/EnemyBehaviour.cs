using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour
{
	public EnemyBehaviourAsset Asset { get { return m_asset; } }

	public EnemyBehaviour(EnemyBehaviourAsset asset)
	{
		m_asset = asset;
	}

	public abstract void StartBehaviour(Enemy enemy);

	public abstract void StopBehaviour(Enemy enemy);

	#region Private

	private EnemyBehaviourAsset m_asset = null;

	#endregion Private
}