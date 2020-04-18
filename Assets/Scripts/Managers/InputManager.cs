using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get { return s_instance; } }

	public delegate void OnInputAxisDelegate(InputAxisType inputType, float value);

	[Serializable]
	public enum InputAxisType
	{
		HORIZONTAL_RAW,
		VERTICAL_RAW,
		HORIZONTAL,
		VERTICAL
	}

	public void RegisterOnInputAxis(InputAxisType inputAxisType, OnInputAxisDelegate method, bool register)
	{
		if (register)
		{
			m_inputDelegates[inputAxisType] += method;
		}
		else
		{
			m_inputDelegates[inputAxisType] -= method;
		}
	}

	#region Private

	private void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Debug.LogError("Second InputManger detected. Deleting it.");
			Destroy(gameObject);
			return;
		}
		m_inputDelegates = new Dictionary<InputAxisType, OnInputAxisDelegate>();
		Array enumValues = Enum.GetValues(typeof(InputAxisType));
		for (int i = 0; i < enumValues.Length; i++)
		{
			m_inputDelegates.Add((InputAxisType)enumValues.GetValue(i), null);
		}
	}

	private void Update()
	{
		float horizontalInputRaw = Input.GetAxisRaw("Horizontal");
		float verticalInputRaw = Input.GetAxisRaw("Vertical");

		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		m_inputDelegates[InputAxisType.HORIZONTAL]?.Invoke(InputAxisType.HORIZONTAL, horizontalInput);
		m_inputDelegates[InputAxisType.HORIZONTAL_RAW]?.Invoke(InputAxisType.HORIZONTAL_RAW, horizontalInputRaw);
		m_inputDelegates[InputAxisType.VERTICAL]?.Invoke(InputAxisType.VERTICAL, verticalInput);
		m_inputDelegates[InputAxisType.VERTICAL_RAW]?.Invoke(InputAxisType.VERTICAL_RAW, verticalInputRaw);
	}

	private Dictionary<InputAxisType, OnInputAxisDelegate> m_inputDelegates = null;
	private static InputManager s_instance = null;

	#endregion Private
}