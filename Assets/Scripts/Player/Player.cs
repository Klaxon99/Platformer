using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerInputHandler _input;
    [SerializeField] private Vampirism _vampirism;

    public bool IsAlive => _health.IsAlive;

    private void Start()
    {
        _vampirism.gameObject.SetActive(false);
    }

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
        _input.OnPressedSkillButton += ActivateVampirism;
    }

    private void OnDisable()
    {
        _health.OnDead -= Dead;
        _input.OnPressedSkillButton -= ActivateVampirism;
    }

    private void ActivateVampirism()
    {
        _vampirism.gameObject.SetActive(true);
    }

    private void Dead()
    {
        _animator.PlayDeadAnimation();
    }
}