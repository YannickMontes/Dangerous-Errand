using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get { return s_instance; } }
	public Player Player { get { return m_playerInstance; } }
	public float MaxContaminationValue { get { return m_maxContaminationValue; } }

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

	[SerializeField]
	private Player m_playerPrefab = null;
	[SerializeField]
	private Transform m_spawnPoint = null;

	[Header("Game Constants")]
	[SerializeField]
	private float m_maxContaminationValue = 100.0f;

	private Player m_playerInstance = null;
	private static GameManager s_instance = null;

	#endregion Private
}