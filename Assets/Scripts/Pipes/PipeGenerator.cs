using System.Collections;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _intervalBetweenSpawn;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _maxSpawnPositionY;

    private void Start()
    {
        Initialize(_template);
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            if (TryGetObject(out GameObject pipe))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
            yield return new WaitForSeconds(_intervalBetweenSpawn);

        }
    }
}
