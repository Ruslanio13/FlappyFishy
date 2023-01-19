using System.Collections;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _intervalBetweenSpawn;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _maxSpawnPositionY;
    public Pipe _lastSpawnedPipe;
    private void Start()
    {
        Initialize(_template);
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            if (AllPoolDisabled() || _lastSpawnedPipe.IsOnSafeDistanceFromX(_camera.transform.position.x))
            {
                SpawnPipeInRandomLocation();
                DisableObjectAbroadScreen();
            }
            yield return new WaitForSeconds(_intervalBetweenSpawn);
        }
    }

    public void SpawnPipeInRandomLocation()
    {
        if (TryGetObject(out _lastSpawnedPipe))
        {
            float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 1);
            _lastSpawnedPipe.gameObject.SetActive(true);
            _lastSpawnedPipe.transform.position = spawnPoint;
        }   
    }
}
