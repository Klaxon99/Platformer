using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}