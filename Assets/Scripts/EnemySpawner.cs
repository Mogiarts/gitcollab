using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public List<Transform> spawnPositions;

    public GameObject _enemyToSpawn;
    public bool shouldSpawnEnemies = false;

    private List<GameObject> _enemiesList;
    private int _spawnInterval = 2;
    private float _elapsedTime;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _enemiesList = new List<GameObject>();
    }
    
    private void Update()
    {
        if (shouldSpawnEnemies)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _spawnInterval)
            {
                SpawnEnemy();
                _elapsedTime = 0;
            }
        }
        Debug.Log(_elapsedTime);
    }

    private void SpawnEnemy()
    {
        GameObject thisEnemy;
        thisEnemy = Instantiate(_enemyToSpawn, spawnPositions[Random.Range(0, 7)].position, Quaternion.identity);
        _enemiesList.Add(thisEnemy);
    }
}
