using UnityEngine;

public class HealthListener : MonoBehaviour
{
    [SerializeField] HealthView _healthView;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnHealthChange += HandleChange;
    }

    private void OnDisable()
    {
        _health.OnHealthChange -= HandleChange;
    }

    private void HandleChange(float health)
    {
        _healthView.DrawHealth(health, _health.MaxValue);
    }
}