using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAsset : ScriptableObject
{
	public float Speed { get { return m_speed; } }
	public int BaseContamination { get { return m_baseContamination; } }

	#region Private

	[SerializeField]
	private float m_speed = 2.0f;

	[SerializeField]
	private int m_baseContamination = 0;

	#endregion Private
}