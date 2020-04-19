using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public delegate void OnContaminationValueChange(float oldValue, float newValue);

	public CharacterAsset Asset { get { return m_asset; } }
	public float ContaminationValue { get { return m_contamination; } }

	public void RegisterContaminationValueChangedListener(OnContaminationValueChange listener, bool register)
	{
		if (register)
		{
			m_contaminationValueListeners += listener;
		}
		else
		{
			m_contaminationValueListeners -= listener;
		}
	}

	#region Private

	protected virtual void Awake()
	{
		m_contamination = Asset.BaseContamination;
		m_animator = GetComponent<Animator>();
	}

	protected virtual void Start()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	[SerializeField]
	private CharacterAsset m_asset = null;

	[NonSerialized]
	protected int m_contamination = 0;
	[NonSerialized]
	protected Animator m_animator = null;
	[NonSerialized]
	protected OnContaminationValueChange m_contaminationValueListeners = null;

	#endregion Private
}