using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int IsRunning = Animator.StringToHash("IsRunning");

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
}