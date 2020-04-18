using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PlayerAsset")]
public class PlayerAsset : CharacterAsset
{
	public Projectile DefaultProjectile { get { return m_defaultProjectilePrefab; } }
	public InputManager.InputAxisType HorizontalInputType { get { return m_horizontalInputType; } }
	public InputManager.InputAxisType VerticalInputType { get { return m_verticalInputType; } }

	#region Private

	[SerializeField]
	private InputManager.InputAxisType m_horizontalInputType = InputManager.InputAxisType.HORIZONTAL;

	[SerializeField]
	private InputManager.InputAxisType m_verticalInputType = InputManager.InputAxisType.VERTICAL;

	[SerializeField]
	private Projectile m_defaultProjectilePrefab = null;

	#endregion Private
}