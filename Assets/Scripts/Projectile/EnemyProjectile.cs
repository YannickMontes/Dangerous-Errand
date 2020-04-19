using System.Collections;
using System.Collections.Generic;

//using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyProjectile : Projectile
{
	public float HitStun { get { return m_hitStun; } }

	#region Private

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		Shield shield = collision.GetComponent<Shield>();
		if (collision.tag == "Player")
		{
			Player player = collision.gameObject.GetComponent<Player>();
			bool received = player.ReceiveProjectile(this);
			if (received)
			{
				ResourceManager.Instance.ReleaseInstance(gameObject);
			}
		}
		else if (shield != null)
		{
			shield.BreakShield();
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
		else
		{
			base.OnTriggerEnter2D(collision);
		}
	}

	[SerializeField]
	private float m_hitStun = 1.5f;

	#endregion Private
}