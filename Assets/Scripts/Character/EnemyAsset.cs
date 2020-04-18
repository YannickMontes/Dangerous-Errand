using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyAsset")]
public class EnemyAsset : CharacterAsset
{
	public IReadOnlyList<EnemyBehaviourAsset> DefaultBehaviours { get { return m_defaultBehaviours; } }

	#region Private

	[SerializeField]
	private List<EnemyBehaviourAsset> m_defaultBehaviours = new List<EnemyBehaviourAsset>();

	#endregion Private
}