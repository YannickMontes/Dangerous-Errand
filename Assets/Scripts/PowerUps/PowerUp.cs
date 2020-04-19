using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
	public abstract void StartPowerUp(Player player);

	#region Private

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.GetComponent<Player>().CollectPowerUp(this);
		}
	}

	#endregion Private
}