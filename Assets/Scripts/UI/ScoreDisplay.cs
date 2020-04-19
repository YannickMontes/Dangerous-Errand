using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
	#region Private

	private void OnEnable()
	{
		ScoringManager.Instance.RegisterOnScoreChange(OnScoreChanged, true);
		OnScoreChanged(ScoringManager.Instance.Score, ScoringManager.Instance.Score);
	}

	private void OnDisable()
	{
		ScoringManager.Instance.RegisterOnScoreChange(OnScoreChanged, true);
	}

	private void OnScoreChanged(int old, int newVal)
	{
		m_scoreValue.text = newVal.ToString();
	}

	[SerializeField]
	private TextMeshProUGUI m_scoreValue = null;

	#endregion Private
}