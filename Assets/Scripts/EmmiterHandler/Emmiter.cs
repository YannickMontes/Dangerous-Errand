using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour
{
	public Projectile ProjectilePrefab { get { return m_projectilePrefab; } }

	#region private

	[SerializeField]
	private Projectile m_projectilePrefab = null;

	#endregion private
}