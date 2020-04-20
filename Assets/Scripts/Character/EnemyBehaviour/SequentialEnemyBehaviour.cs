using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialEnemyBehaviour : EnemyBehaviour
{
	public new SequentialEnemyBehaviourAsset Asset { get { return base.Asset as SequentialEnemyBehaviourAsset; } }

	public SequentialEnemyBehaviour(EnemyBehaviourAsset asset) : base(asset)
	{
	}

	public override void StartBehaviour(Enemy enemy)
	{
		m_coroutine = RunBehaviour(enemy);
		enemy.StartCoroutine(m_coroutine);
	}

	public override void StopBehaviour(Enemy enemy)
	{
		enemy.StopCoroutine(m_coroutine);
		if (m_currentBehaviour != null)
		{
			ResourceManager.Instance.ReleaseInstance(m_currentBehaviour.gameObject);
		}
	}

	private IEnumerator RunBehaviour(Enemy enemy)
	{
		while (m_coroutine != null)
		{
			EnemyBehaviourAsset.ProjectileBehaviour projBehaviour = Asset.ProjectileBehaviours[m_currentIndex];
			m_currentBehaviour = ResourceManager.Instance.AcquireInstance(projBehaviour.EmmiterHandlerPrefab, enemy.transform);
			float elapsedTime = 0.0f;
			while (projBehaviour.ActiveTime == -1 || elapsedTime < projBehaviour.ActiveTime)
			{
				AudioClip projSound = null;
				foreach (Emmiter emmiter in m_currentBehaviour.Emitters)
				{
					Projectile proj = ResourceManager.Instance.AcquireInstance(emmiter.ProjectilePrefab, emmiter.transform);
					proj.transform.SetParent(null); //Deparent it to avoid problems
					projSound = proj.GetRandomAudioClip();
				}
				enemy.PlayShootAnim();
				if (projSound != null)
				{
					enemy.PlaySound(projSound);
				}
				yield return new WaitForSeconds(projBehaviour.ShootTime);
				if (m_coroutine == null)
				{
					yield break;
				}
				elapsedTime += projBehaviour.ShootTime;
			}
			ResourceManager.Instance.ReleaseInstance(m_currentBehaviour.gameObject);
			m_currentBehaviour = null;
			m_currentIndex++;
			if (m_currentIndex >= Asset.ProjectileBehaviours.Count)
			{
				m_currentIndex = 0;
			}
			yield return new WaitForSeconds(Asset.WaitTime);
		}
	}

	private int m_currentIndex = 0;
	private IEnumerator m_coroutine = null;
	private EmmiterHandler m_currentBehaviour = null;
}