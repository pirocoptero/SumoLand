using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveCount = 1;
    void Awake()
    {
        SpawnEnemyWave(waveCount);
        Instantiate(powerUpPrefab, SpawnRandomPosition(), transform.rotation);
    }
    
    void Update() {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if(enemyCount == 0) {
            waveCount++;
            SpawnEnemyWave(waveCount);
            Instantiate(powerUpPrefab, SpawnRandomPosition(), transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        for(int i = 0 ; i < enemiesToSpawn ; i++) {
            Instantiate(enemyPrefab, SpawnRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 SpawnRandomPosition() {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, -spawnRange);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

        return randomPosition;
    }

}
