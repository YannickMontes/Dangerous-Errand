using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance { get { return s_instance; } }

	#region Private

	private void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private static UIManager s_instance = null;

	#endregion Private
}