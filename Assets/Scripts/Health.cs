using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action HealthChanged;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get { return _maxHealth; } }

    private void Awake()
    {
        CurrentHealth = _maxHealth; 
    }

    private void OnEnable()
    {
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        CurrentHealth -= damage;

        if(CurrentHealth < 0)
            CurrentHealth = 0;

        HealthChanged?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        CurrentHealth += heal;

        if(CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;

        HealthChanged?.Invoke();
    }
}
