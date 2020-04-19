using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
	public delegate void OnScoreChange(int oldValue, int newValue);

	public static ScoringManager Instance { get { return s_instance; } }
	public int Score { get { return m_score; } }

	public void IncreaseScore(int value)
	{
		int oldValue = m_score;
		m_score += value;
		m_scoreChangedListeners?.Invoke(oldValue, m_score);
	}

	public void RegisterOnScoreChange(OnScoreChange method, bool register)
	{
		if (register)
		{
			m_scoreChangedListeners += method;
		}
		else
		{
			m_scoreChangedListeners -= method;
		}
	}

	private void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
			GameManager.Instance.RegisterStateListener(OnGameManagerState, true);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		GameManager.Instance?.RegisterStateListener(OnGameManagerState, false);
	}

	private void OnGameManagerState(GameManager.State state)
	{
		if (state == GameManager.State.VICTORY)
		{
			m_score += m_finishLevelScore;
		}
	}

	[SerializeField]
	private int m_finishLevelScore = 500;

	[NonSerialized]
	private int m_score = 0;
	[NonSerialized]
	private OnScoreChange m_scoreChangedListeners = null;
	private static ScoringManager s_instance = null;
}