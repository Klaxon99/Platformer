using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth;
    private float _minHealth;

    public event Action OnDead;

    public bool IsAlive => _health > _minHealth;

    private void Start()
    {
        _maxHealth = 100;
        _minHealth = 0;
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _health = Mathf.Max(_health - damage, _minHealth);    
        }

        if (IsAlive == false)
        {
            OnDead?.Invoke();
        }
    }

    public void Recovery(float healthCount)
    {
        if (healthCount > 0)
        {
            _health = Mathf.Min(_health + healthCount, _maxHealth);
        }
    }
}