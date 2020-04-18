using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public static Projectile AcquireInstance(Projectile prefab, Transform parent, Vector3 position)
	{
		Projectile proj = ResourceManager.Instance.AcquireInstance(prefab, parent);
		proj.transform.position = position;
		return proj;
	}

	#region Private

	private void FixedUpdate()
	{
		transform.Translate(Vector2.up * m_speed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Border")
		{
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
	}

	[SerializeField]
	private float m_speed = 1.0f;

	#endregion Private
}