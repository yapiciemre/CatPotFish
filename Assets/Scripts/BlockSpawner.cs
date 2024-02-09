using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject blockPrefab;
    public GameObject coinPrefab;

    public float initialSpawnInterval = 3f; // Ba�lang�� spawn aral���
    public float minSpawnInterval = 0.5f; // En d���k spawn aral���
    public float spawnIntervalDecreaseRate = 0.05f; // Zorluk seviyesinin azalma h�z�

    private float currentSpawnInterval; // �u anki spawn aral���
    private float timeToSpawn = 0f;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + currentSpawnInterval;

            // Zorluk seviyesini art�r�n ve minSpawnInterval'i kontrol edin
            if (currentSpawnInterval > minSpawnInterval)
            {
                currentSpawnInterval -= spawnIntervalDecreaseRate;
            }
        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }

        // Bo� kalan k�sma para prefab�n� yerle�tir
        Instantiate(coinPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
