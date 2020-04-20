using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	public void BreakShield()
	{
		if (!m_isBroken)
		{
			m_animator.SetTrigger("Break");
			m_isBroken = true;
		}
	}

	//Trigger by anim event
	public void Disable()
	{
		gameObject.SetActive(false);
	}

	#region Private

	private void Awake()
	{
		m_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!gameObject.activeInHierarchy)
			return;
		if (collision.tag == "Enemy")
		{
			Enemy enemy = collision.GetComponent<Enemy>();
			if (enemy.IsAlive)
			{
				BreakShield();
				enemy.Kill();
			}
		}
	}

	[NonSerialized]
	private Animator m_animator = null;
	[NonSerialized]
	private bool m_isBroken = false;

	#endregion Private
}