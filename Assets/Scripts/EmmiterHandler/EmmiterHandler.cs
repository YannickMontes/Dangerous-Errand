using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EmmiterHandler : MonoBehaviour
{
	public IReadOnlyList<Emmiter> Emitters { get { return m_emitters; } }

	public virtual void StartBehaviour()
	{
		m_isStarted = true;
	}

	public virtual void StopBehaviour()
	{
		m_isStarted = false;
	}

	#region Private

	private void OnEnable()
	{
		StartBehaviour();
	}

	private void OnDisable()
	{
		StopBehaviour();
	}

	private void FixedUpdate()
	{
		if (m_isStarted)
		{
			DoTreatment();
		}
	}

	protected abstract void DoTreatment();

	[SerializeField]
	private List<Emmiter> m_emitters = new List<Emmiter>();
	[SerializeField]
	protected Transform m_emmiterParent = null;

	[NonSerialized]
	private bool m_isStarted = false;

	#endregion Private
}