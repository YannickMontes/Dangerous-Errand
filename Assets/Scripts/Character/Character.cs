using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public CharacterAsset Asset { get { return m_asset; } }

	#region Private

	private void Awake()
	{
		m_contamination = Asset.BaseContamination;
	}

	[SerializeField]
	private CharacterAsset m_asset = null;

	[NonSerialized]
	protected int m_contamination = 0;

	#endregion Private
}