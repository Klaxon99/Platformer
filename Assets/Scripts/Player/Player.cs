using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] PlayerAnimator _animator;

    private float _health;
    private float _maxHealth;
    private float _minHealth;

    public bool IsAlive => _health > _minHealth;

    private void Start()
    {
        _maxHealth = 100;
        _health = _maxHealth;
        _minHealth = 0;
    }

    private void Dead()
    {
        _animator.PlayDeadAnimation();
    }

    public void RecoveryHealth(float healthCount)
    {
        _health = Mathf.Min(_health + healthCount, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Max(_health - damage, _minHealth);

        if (_health == _minHealth)
        {
            Dead();
        }
    }
}