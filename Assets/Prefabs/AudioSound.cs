using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSound : MonoBehaviour
{
	public void PlayClip(AudioClip clip)
	{
		m_audioSource.clip = clip;
		m_audioSource.Play();
	}

	#region private

	private void Awake()
	{
		m_audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!m_audioSource.isPlaying)
		{
			ResourceManager.Instance.ReleaseInstance(gameObject);
		}
	}

	private AudioSource m_audioSource = null;

	#endregion private
}