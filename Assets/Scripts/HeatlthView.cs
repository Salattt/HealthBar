using UnityEngine;

public abstract class HeatlthView : MonoBehaviour
{
    [SerializeField] private Health _health;


    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    private  void OnHealthChanged()
    {
        UpdateHealth(_health.Current, _health.Max);
    }

    protected abstract void UpdateHealth(float currentHealth, float maxHealth);
}
