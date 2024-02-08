using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Health _skillOwner;
    [SerializeField] private float _stealingHealthSpeed;

    private Health _target;
    private float _activityTime = 6f;
    private float _activityTimer = 0f;

    private void Update()
    {
        if (_activityTimer >= _activityTime)
        {
            gameObject.SetActive(false);
            _activityTimer = 0f;
        }

        _activityTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
        {
            _target = enemy;
            StartCoroutine(StealHealth());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _target = null;
    }

    private IEnumerator StealHealth()
    {
        float healthPerItearate = _stealingHealthSpeed * Time.deltaTime;

        while (_target != null)
        {
            _target.TakeDamage(healthPerItearate);
            _skillOwner.Recovery(healthPerItearate);

            yield return null;
        }
    }
}