using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSpeed;

    private Coroutine _coroutine;

    public override void DrawHealth(float currentHealth, float maxHealth)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeHealth(currentHealth / maxHealth));
    }

    private IEnumerator ChangeHealth(float targetaValue)
    {
        while (_slider.value != targetaValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetaValue, _changeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}