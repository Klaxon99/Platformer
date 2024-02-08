using UnityEngine;

public class Wallet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }
}