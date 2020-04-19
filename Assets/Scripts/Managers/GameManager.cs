using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum State
	{
		DEFAULT,
		VICTORY,
		GAME_OVER
	}

	public delegate void OnState(State evt);

	public static GameManager Instance { get { return s_instance; } }
	public Player Player { get { return m_playerInstance; } }
	public float MaxContaminationValue { get { return m_maxContaminationValue; } }
	public State CurrentState { get { return m_currentState; } }

	public void RegisterStateListener(OnState listener, bool register)
	{
		if (register)
		{
			m_onEventListeners += listener;
		}
		else
		{
			m_onEventListeners -= listener;
		}
	}

	#region Private

	private void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
			m_playerInstance = GameObject.Instantiate<Player>(m_playerPrefab);
			m_playerInstance.transform.position = m_spawnPoint.position;
			m_playerInstance.transform.rotation = m_spawnPoint.rotation;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		Player.RegisterContaminationValueChangedListener(OnPlayerContaminationChanged, true);
		ChangeState(State.DEFAULT);
	}

	private void Update()
	{
		if (CurrentState == State.DEFAULT)
		{
			if (!m_enemyToKill.IsAlive)
			{
				ChangeState(State.VICTORY);
			}
		}
	}

	private void OnPlayerContaminationChanged(float oldValue, float newValue)
	{
		if (newValue >= m_maxContaminationValue)
		{
			Debug.Log("Covid-19 get your fat ass modafucka");
			ChangeState(State.GAME_OVER);
		}
	}

	private void ChangeState(State evt)
	{
		if (evt != m_currentState)
		{
			m_currentState = evt;
			m_onEventListeners?.Invoke(m_currentState);

			if (m_currentState != State.DEFAULT)
			{
				InputManager.Instance.gameObject.SetActive(false);
			}
		}
	}

	[SerializeField]
	private Player m_playerPrefab = null;
	[SerializeField]
	private Transform m_spawnPoint = null;

	[Header("Game Constants")]
	[SerializeField]
	private float m_maxContaminationValue = 100.0f;

	[Header("Victory conditions")]
	[SerializeField]
	private Enemy m_enemyToKill = null;

	private Player m_playerInstance = null;
	private static GameManager s_instance = null;
	private OnState m_onEventListeners = null;
	private State m_currentState = default(State);

	#endregion Private
}