using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
	#region Private

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			enemy.DecreaseContamination(m_contaminationValue);
			ReleaseProjectile();
		}
		else //Putting it on a else to avoid double release
		{
			base.OnTriggerEnter2D(collision);
		}
	}

	#endregion Private
}