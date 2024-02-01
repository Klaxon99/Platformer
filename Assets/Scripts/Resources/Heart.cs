using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] float _healthRecoveryCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.RecoveryHealth(_healthRecoveryCount);
            Destroy(gameObject);
        }
    }
}
