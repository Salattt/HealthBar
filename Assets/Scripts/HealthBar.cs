using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : HeatlthView
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void UpdateHealth(float currentHealth, float maxHealth)
    {
        _slider.value = currentHealth / maxHealth;
    }
}
