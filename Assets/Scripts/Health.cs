using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;

    public event Action Changed;

    public float Current { get; private set; }
    public float Max { get { return _max; } }

    private void Awake()
    {
        Current = _max; 
    }

    private void OnEnable()
    {
        Changed?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Current -= damage;

        if(Current < 0)
            Current = 0;

        Changed?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        Current += heal;

        if(Current > _max)
            Current = _max;

        Changed?.Invoke();
    }
}
