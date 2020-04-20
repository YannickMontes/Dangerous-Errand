using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPage : MonoBehaviour
{
	#region Private

	private void Start()
	{
		GameManager.Instance.RegisterStateListener(OnGameMangerStateChanged, true);
		OnGameMangerStateChanged(GameManager.Instance.CurrentState);
	}

	private void OnDestroy()
	{
		GameManager.Instance?.RegisterStateListener(OnGameMangerStateChanged, false);
	}

	private void OnGameMangerStateChanged(GameManager.State evt)
	{
		gameObject.SetActive(evt == m_displayOnState);
	}

	[SerializeField]
	private GameManager.State m_displayOnState = default(GameManager.State);

	#endregion Private
}