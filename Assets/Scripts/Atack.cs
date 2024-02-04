using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health targetHealth))
        {
            targetHealth.TakeDamage(_damage);
        }
    }
}