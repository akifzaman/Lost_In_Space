using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class HealthBar : MonoBehaviour
	{
		[HideInInspector] public UnityEvent OnMaximumValue;

		private float currentBulletTaken = 0;
		private Slider healthBarSlider;

		public void Initialize(float healthValue)
		{
			healthBarSlider = GetComponent<Slider>();
			healthBarSlider.maxValue = healthValue;
			healthBarSlider.value = 0;
			healthBarSlider.onValueChanged.AddListener(OnUpdateSlider);
		}

		private void OnUpdateSlider(float sliderValue)
		{
			if (currentBulletTaken >= healthBarSlider.maxValue)
			{
				OnMaximumValue.Invoke();
			}
		}

		public void UpdateSlider(float amount)
		{
			currentBulletTaken = amount == 0 ? 0 : currentBulletTaken += amount;
			healthBarSlider.value = currentBulletTaken;
		}
	}
}
