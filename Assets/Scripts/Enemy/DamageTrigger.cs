using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(_enemy.gameObject);
        }
    }
}
