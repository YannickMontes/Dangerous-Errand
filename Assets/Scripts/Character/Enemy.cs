using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
	public new EnemyAsset Asset { get { return base.Asset as EnemyAsset; } }

	public bool IsAlive { get { return m_contamination > 0; } }

	public void DecreaseContamination(int value)
	{
		if (m_contamination > 0)
		{
			float oldValue = m_contamination;
			m_contamination -= value;
			m_contaminationValueListeners?.Invoke(oldValue, m_contamination);
			if (m_contamination <= 0)
			{
				ScoringManager.Instance.IncreaseScore(Asset.KillScore);
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

	public void Kill()
	{
		DecreaseContamination((int)ContaminationValue);
	}

	#region Private

	protected override void Awake()
	{
		base.Awake();
		foreach (EnemyBehaviourAsset behaviourAsset in Asset.DefaultBehaviours)
		{
			m_behaviours.Add(behaviourAsset.CreateBehaviour());
		}
	}

	protected void StartBehaviours()
	{
		if (!m_behaviourStarted)
		{
			m_behaviourStarted = true;
			foreach (EnemyBehaviour behaviour in m_behaviours)
			{
				behaviour.StartBehaviour(this);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "EnemyActivator")
		{
			StartBehaviours();
		}
	}

	[SerializeField]
	private List<EnemyBehaviour> m_behaviours = new List<EnemyBehaviour>();

	[NonSerialized]
	private bool m_behaviourStarted = false;

	#endregion Private
}