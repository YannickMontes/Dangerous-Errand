using System;
using UnityEngine;

public class RotateProjectileHandler : ProjectileHandler
{
	[Serializable]
	public enum Behaviour
	{
		RESET,
		GO_BACK,
		CONTINUE
	}

	public override void StartBehaviour()
	{
		base.StartBehaviour();
		m_emmiterParent.transform.up = m_beginPoint.position - m_emmiterParent.transform.position;
	}

	public override void StopBehaviour()
	{
		base.StopBehaviour();
		m_isRunningBackward = false;
	}

	#region Private

	protected override void DoTreatment()
	{
		Vector3 beginDirection = m_beginPoint.position - transform.position;
		Vector3 endDirection = m_endPoint.position - transform.position;

		switch (m_behaviour)
		{
			case Behaviour.RESET:
				float angle = Vector3.SignedAngle(m_emmiterParent.up, endDirection, Vector3.forward);
				if (angle - EPSILON <= 0 && 0 <= angle + EPSILON)
				{
					transform.up = beginDirection;
				}
				break;

			case Behaviour.GO_BACK:
				float endAngle = Vector3.SignedAngle(m_emmiterParent.up, endDirection, Vector3.forward);
				float beginAngle = Vector3.SignedAngle(m_emmiterParent.up, beginDirection, Vector3.forward);
				if (!m_isRunningBackward && endAngle - EPSILON <= 0 && 0 <= endAngle + EPSILON)
				{
					m_isRunningBackward = true;
				}
				else if (m_isRunningBackward && beginAngle - EPSILON <= 0 && 0 <= beginAngle + EPSILON)
				{
					m_isRunningBackward = false;
				}
				break;
		}

		m_emmiterParent.Rotate((m_isRunningBackward ? -1 : 1) * Vector3.forward * m_rotateSpeed * Time.fixedDeltaTime);
	}

	[SerializeField]
	private Behaviour m_behaviour = default(Behaviour);

	[SerializeField]
	private Transform m_beginPoint = null;

	[SerializeField]
	private Transform m_endPoint = null;

	[SerializeField]
	private float m_rotateSpeed = 25.0f;

	[NonSerialized]
	private bool m_isRunningBackward = false;

	private const float EPSILON = 1.0f;

	#endregion Private
}