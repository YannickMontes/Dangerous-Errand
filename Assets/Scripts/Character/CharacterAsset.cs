using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAsset : ScriptableObject
{
	public float Speed { get { return m_speed; } }

	#region Private

	[SerializeField]
	private float m_speed = 2.0f;

	#endregion Private
}