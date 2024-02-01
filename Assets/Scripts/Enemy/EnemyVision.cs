using UnityEngine;

public class EnemyVision : MonoBehaviour
{ 
    public bool HasTarget => _target != null;

    private Transform _target = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _target = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _target = null;
        }
    }

    public bool TryGetTargetPosition(out Vector3 target)
    {
        target = HasTarget ? _target.transform.position : Vector3.zero;

        return HasTarget;
    }
}