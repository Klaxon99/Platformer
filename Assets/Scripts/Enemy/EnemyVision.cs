using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{ 
    public event Action<Transform> OnFoundTarget;
    public event Action OnLoseTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            OnFoundTarget?.Invoke(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            OnLoseTarget?.Invoke();
        }
    }
}