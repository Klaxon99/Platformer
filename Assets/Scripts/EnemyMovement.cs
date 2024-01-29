using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _patrollingDistance;
    [SerializeField] private float _movementSpeed;

    private Vector3[] _patrollingPlaces;

    private void Start()
    {
        Vector3 endPlace = transform.position;
        Vector3 startPlace = new Vector3(endPlace.x + _patrollingDistance, endPlace.y, endPlace.z);
        _patrollingPlaces = new Vector3[] {startPlace, endPlace};

        StartCoroutine(TranslatePositions());
    }

    private IEnumerator TranslatePositions()
    {
        int currentPlaceIndex = 0;

        while(enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _patrollingPlaces[currentPlaceIndex], _movementSpeed * Time.deltaTime);

            yield return null;

            if (transform.position == _patrollingPlaces[currentPlaceIndex])
            {
                currentPlaceIndex++;
                currentPlaceIndex %= _patrollingPlaces.Length;
            }
        }
    }
}