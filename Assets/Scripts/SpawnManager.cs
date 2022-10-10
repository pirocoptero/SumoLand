using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    void Start()
    {
        Instantiate(enemyPrefab, spawnEnemyRandomPosition(), enemyPrefab.transform.rotation);
    }

    Vector3 spawnEnemyRandomPosition() {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, -spawnRange);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

        return randomPosition;
    }

}
