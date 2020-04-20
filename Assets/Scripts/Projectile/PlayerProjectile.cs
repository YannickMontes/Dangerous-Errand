using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
	#region Private

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (!gameObject.activeInHierarchy)
			return;
		if (m_touchEnemy && collision.tag == "Enemy")
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			enemy.DecreaseContamination(m_contaminationValue);
			ReleaseProjectile();
		}
		else if (m_touchProjectiles)
		{
			Projectile proj = collision.GetComponent<Projectile>();
			if (proj != null)
			{
				ReleaseProjectile();
				proj.ReleaseProjectile();
			}
		}
		else //Putting it on a else to avoid double release
		{
			base.OnTriggerEnter2D(collision);
		}
	}

	private void Update()
	{
		if (m_touchProjectiles)
		{
			ContactFilter2D filter = new ContactFilter2D();
			filter.NoFilter();
			Collider2D[] results = new Collider2D[10];
			if (Physics2D.OverlapBox(transform.position, m_collider.bounds.size, 360f, filter, results) > 0)
			{
				for (int i = 0; i < results.Length; i++)
				{
					if (results[i] != null && results[i].tag == "Projectile" && results[i].gameObject != gameObject)
					{
						Projectile proj = results[i].GetComponent<Projectile>();
						proj.ReleaseProjectile();
						ReleaseProjectile();
						return;
					}
				}
			}
		}
	}

	[SerializeField]
	private bool m_touchEnemy = true;
	[SerializeField]
	private bool m_touchProjectiles = true;

	#endregion Private
}