using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAsset : ScriptableObject
{
	public int BaseContamination { get { return m_baseContamination; } }
	public float TimeBetweenShoot { get { return m_timeBetweenShoot; } }
	public float Speed { get { return m_speed; } }
	public Projectile DefaultProjectile { get { return m_defaultProjectilePrefab; } }

	#region Private

	[SerializeField]
	private int m_baseContamination = 0;

	[SerializeField]
	private float m_speed = 2.0f;

	[SerializeField]
	private float m_timeBetweenShoot = 2.0f;

	[SerializeField]
	private Projectile m_defaultProjectilePrefab = null;

	#endregion Private
}