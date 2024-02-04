using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerInputHandler _input;

    public bool IsAlive => _health.IsAlive;

    private void Update()
    {
        if (IsAlive)
        {
            Vector3 direction = new Vector3 (_input.HorizontalInput, 0);

            _mover.Move(direction);

            if (direction.x != 0)
            {
                _animator.PlayRunningAnimation();
            }
            else
            {
                _animator.StopRunningAnimation();
            }

            if (_input.VerticalInput)
            {
                _jumper.Jump();
            }
        }
    }

    private void OnEnable()
    {
        _health.OnDead += Dead;
    }

    private void OnDisable()
    {
        _health.OnDead -= Dead;
    }

    private void Dead()
    {
        _animator.PlayDeadAnimation();
    }
}