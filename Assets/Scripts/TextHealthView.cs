using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthView : HeatlthView
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void UpdateHealth(float currentHealth, float maxHealth)
    {
        _text.text = $"{currentHealth}/{maxHealth}";
    }
}
