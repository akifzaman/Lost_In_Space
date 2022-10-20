using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealthBar : MonoBehaviour
{
    public UnityEvent OnMaximumValue;

    public float maximumDamageValue; 
    private float currentBulletTaken = 0; 

    private Slider healthBarSlider;
    public void Initialize()
    {
        healthBarSlider = GetComponent<Slider>();
        healthBarSlider.maxValue = maximumDamageValue; 
        healthBarSlider.value = 0;
    }

    public void UpdateSlider(float amount)
    {
        healthBarSlider.value = amount == 0 ? 0 : currentBulletTaken += amount;

        if (currentBulletTaken >= maximumDamageValue)
        {
            OnMaximumValue.Invoke();
        }
    }
}
