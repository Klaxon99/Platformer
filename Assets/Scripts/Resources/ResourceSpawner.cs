using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] GameObject[] _resourcesPrefabs;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            int resourceRandomIndex = Random.Range(0, _resourcesPrefabs.Length);

            Spawn(spawnPoint, _resourcesPrefabs[resourceRandomIndex]);
        }
    }

    private void Spawn(SpawnPoint spawnPoint, GameObject prefab)
    {
        Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
    }
}