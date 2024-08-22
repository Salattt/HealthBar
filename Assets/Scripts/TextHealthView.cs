using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void  OnHealthChanged()
    {
        _text.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}
