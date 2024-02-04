using UnityEngine;

[RequireComponent (typeof(Health))]
public class Healer : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Heart heart))
        {
            _health.Recovery(heart.HealthRecoveryCount);
            Destroy(heart.gameObject);
        }
    }
}