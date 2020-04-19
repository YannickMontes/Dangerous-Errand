using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintYTransformAxis : MonoBehaviour
{
	#region private

	private void Update()
	{
		transform.up = m_constraintDirection;
	}

	[SerializeField]
	private Vector3 m_constraintDirection = Vector3.up;

	#endregion private
}