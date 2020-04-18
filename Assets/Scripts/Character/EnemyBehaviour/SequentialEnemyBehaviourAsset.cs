using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyBehaviours/Sequential")]
public class SequentialEnemyBehaviourAsset : EnemyBehaviourAsset
{
	public float WaitTime { get { return m_waitTime; } }
	public IReadOnlyList<ProjectileBehaviour> ProjectileBehaviours { get { return m_projectileBehaviours; } }

	public override EnemyBehaviour CreateBehaviour()
	{
		return new SequentialEnemyBehaviour(this);
	}

	[SerializeField]
	private List<ProjectileBehaviour> m_projectileBehaviours = new List<ProjectileBehaviour>();
	[SerializeField]
	private float m_waitTime = 1.0f;
}