using System;
using System.Collections;
using System.Collections.Generic;

//using UnityEditor.VersionControl;
using UnityEngine;

public class Enemy : Character
{
	public new EnemyAsset Asset { get { return base.Asset as EnemyAsset; } }

	public void DecreaseContamination(int value)
	{
		if (m_contamination >= 0)
		{
			m_contamination -= value;
			if (m_contamination <= 0)
			{
				m_animator.SetBool("Healed", true);
				foreach (EnemyBehaviour behaviour in m_behaviours)
				{
					behaviour.StopBehaviour(this);
				}
			}
		}
	}

	public void PlayShootAnim()
	{
		m_animator.SetTrigger("Shoot");
	}

	#region Private

	protected override void Awake()
	{
		base.Awake();
		m_animator = GetComponent<Animator>();
		foreach (EnemyBehaviourAsset behaviourAsset in Asset.DefaultBehaviours)
		{
			m_behaviours.Add(behaviourAsset.CreateBehaviour());
		}
	}

	protected override void Start()
	{
		base.Start();
		foreach (EnemyBehaviour behaviour in m_behaviours)
		{
			behaviour.StartBehaviour(this);
		}
	}

	[SerializeField]
	private List<EnemyBehaviour> m_behaviours = new List<EnemyBehaviour>();

	[NonSerialized]
	private Animator m_animator = null;

	#endregion Private
}