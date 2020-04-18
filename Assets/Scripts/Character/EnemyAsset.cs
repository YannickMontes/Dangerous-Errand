using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyAsset")]
public class EnemyAsset : CharacterAsset
{
	public float TimeBetweenShoot { get { return m_timeBetweenShoot; } }

	[SerializeField]
	private float m_timeBetweenShoot = 2.0f;
}