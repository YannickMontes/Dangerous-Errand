using System.Collections;
using System.Collections.Generic;

//using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyProjectile : Projectile
{
	#region Private

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
		if (collision.tag == "Player")
		{
			Player player = collision.gameObject.GetComponent<Player>();
			player.IncreaseContamination(m_contaminationValue);
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
	}

	#endregion Private
}