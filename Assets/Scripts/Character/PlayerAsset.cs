using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PlayerAsset")]
public class PlayerAsset : CharacterAsset
{
	public InputManager.InputAxisType HorizontalInputType { get { return m_horizontalInputType; } }
	public InputManager.InputAxisType VerticalInputType { get { return m_verticalInputType; } }

	#region Private

	[SerializeField]
	private InputManager.InputAxisType m_horizontalInputType = InputManager.InputAxisType.HORIZONTAL;

	[SerializeField]
	private InputManager.InputAxisType m_verticalInputType = InputManager.InputAxisType.VERTICAL;

	#endregion Private
}