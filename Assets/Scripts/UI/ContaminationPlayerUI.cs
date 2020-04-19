using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContaminationPlayerUI : MonoBehaviour
{
	private void OnEnable()
	{
		GameManager.Instance.Player.RegisterContaminationValueChangedListener(OnPlayerContaminationChanged, true);
		OnPlayerContaminationChanged(GameManager.Instance.Player.ContaminationValue, GameManager.Instance.Player.ContaminationValue);
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		GameManager.Instance.Player.RegisterContaminationValueChangedListener(OnPlayerContaminationChanged, false);
	}

	private void OnPlayerContaminationChanged(float oldValue, float newValue)
	{
		StopAllCoroutines();
		StartCoroutine(LerpSlider(oldValue, newValue));
	}

	private IEnumerator LerpSlider(float oldValue, float newValue)
	{
		float elapsedTime = 0.0f;
		while (elapsedTime < m_timeToFill)
		{
			elapsedTime += Time.deltaTime;
			m_fillImage.fillAmount = Mathf.Lerp(oldValue / GameManager.Instance.MaxContaminationValue
				, newValue / GameManager.Instance.MaxContaminationValue
				, elapsedTime / m_timeToFill);
			yield return null;
		}
		m_fillImage.fillAmount = newValue / GameManager.Instance.MaxContaminationValue;
	}

	[SerializeField]
	private Image m_fillImage = null;
	[SerializeField]
	private float m_timeToFill = 1.5f;
}