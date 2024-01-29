using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawnPoint[] _coinSpawnPoints;
    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        foreach (CoinSpawnPoint spawnPoint in _coinSpawnPoints)
        {
            Instantiate(_coinPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}