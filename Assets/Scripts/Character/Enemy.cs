using System;
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

	#region Private

	protected override void Awake()
	{
		m_animator = GetComponent<Animator>();
		StartCoroutine(Shoot());
	}

	private IEnumerator Shoot()
	{
		while (true)
		{
			yield return new WaitForSeconds(Asset.TimeBetweenShoot);
			Projectile projectile = Projectile.AcquireInstance(Asset.DefaultProjectile, null, transform.position, Vector2.down);
			m_animator.SetTrigger("Shoot");
		}
	}

	[NonSerialized]
	private Animator m_animator = null;

	#endregion Private
}