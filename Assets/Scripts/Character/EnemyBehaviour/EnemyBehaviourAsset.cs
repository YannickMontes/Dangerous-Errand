using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviourAsset : ScriptableObject
{
	public abstract EnemyBehaviour CreateBehaviour();

	[Serializable]
	public class ProjectileBehaviour
	{
		public float ActiveTime = 5.0f;
		public float ShootTime = 0.5f;
		public EmmiterHandler EmmiterHandlerPrefab = null;
	}
}