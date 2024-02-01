using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int IsRunning = Animator.StringToHash("IsRunning");
    private readonly int IsDead = Animator.StringToHash("IsDead");

    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator> ();
    }

    public void PlayRunningAnimation()
    {
        _animator.SetBool(IsRunning, true);
    }

    public void StopRunningAnimation()
    {
        _animator.SetBool(IsRunning, false);
    }

    public void PlayDeadAnimation()
    {
        _animator.SetBool(IsDead, true);
    }
}