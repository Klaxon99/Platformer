using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private Health _health;
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField] private float _patrollingDistance;

    private Transform _target;
    private Vector3 _patrollingPosition;
    private Vector3 _patrollingDirection;

    private void Start()
    {
        _patrollingDirection = new Vector3(_patrollingDistance, 0);
        _patrollingPosition = transform.position + _patrollingDirection;
    }

    private void Update()
    {
        if (_target != null)
        {
            _mover.Move((_target.transform.position - transform.position).normalized);
        }
        else
        {
            _mover.MoveTowards(_patrollingPosition);

            if (transform.position == _patrollingPosition)
            {
                RotatePatrollingPosition();
            }
        }
    }

    private void OnEnable()
    {
        _health.OnDead += Dead;
        _enemyVision.OnFoundTarget += SetTarget;
        _enemyVision.OnLoseTarget += ResetTarget;
    }

    private void OnDisable()
    {
        _health.OnDead -= Dead;
        _enemyVision.OnFoundTarget -= SetTarget;
        _enemyVision.OnLoseTarget -= ResetTarget;
    }

    private void RotatePatrollingPosition()
    {
        _patrollingDirection *= -1;
        _patrollingPosition += _patrollingDirection;
    }

    private void SetTarget(Transform target)
    {
        _target = target;
    }

    private void ResetTarget()
    {
        _target = null;
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}