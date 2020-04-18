using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public CharacterAsset Asset { get { return m_asset; } }

	#region Private

	[SerializeField]
	private CharacterAsset m_asset = null;

	#endregion Private
}