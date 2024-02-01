using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private float _patrollingDistance;

    private Vector3[] _patrolingPlaces;
    private Vector3 _targetPosition;
    private int _targetPlaceIndex;

    private void Start()
    {
        _targetPlaceIndex = 0;
        Vector3 endPlace = transform.position;
        Vector3 startPlace = new Vector3(endPlace.x + _patrollingDistance, endPlace.y);
        _patrolingPlaces = new Vector3[] {startPlace, endPlace};
        _targetPosition = _patrolingPlaces[_targetPlaceIndex];
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (_vision.TryGetTargetPosition(out Vector3 target))
        {
            _targetPosition = target;
        }
        else
        {
            _targetPosition = _patrolingPlaces[_targetPlaceIndex];
        }
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);

            yield return null;

            if (transform.position == _targetPosition)
            {
                _targetPlaceIndex++;
                _targetPlaceIndex %= _patrolingPlaces.Length;
                _targetPosition = _patrolingPlaces[_targetPlaceIndex];
            }
        }
    }
}