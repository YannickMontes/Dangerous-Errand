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
		if (m_contamination <= 0)
		{
			m_animator.SetBool("Healed", true);
		}
	}

	#region Private

	protected override void Awake()
	{
		base.Awake();
		m_animator = GetComponent<Animator>();
		StartCoroutine(Shoot());
	}

	private IEnumerator Shoot()
	{
		yield return new WaitForSeconds(Asset.TimeBetweenShoot);
		while (m_contamination > 0)
		{
			Projectile projectile = Projectile.AcquireInstance(Asset.DefaultProjectile, null, transform.position, Vector2.down);
			m_animator.SetTrigger("Shoot");
			yield return new WaitForSeconds(Asset.TimeBetweenShoot);
		}
	}

	[NonSerialized]
	private Animator m_animator = null;

	#endregion Private
}