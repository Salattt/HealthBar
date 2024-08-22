using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _sliderSpeed;

    private Slider _slider;
    private Coroutine _valueChanger;
    private bool _isValueChanging = false;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    protected void OnHealthChanged()
    {
        if (_isValueChanging)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ChangeValue(_health.CurrentHealth / _health.MaxHealth));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        WaitForSeconds delay = new WaitForSeconds(Time.fixedDeltaTime);
        _isValueChanging = true;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _sliderSpeed);

            yield return delay;
        }

        _isValueChanging = false;
    }
}
