using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject blockPrefab;
    public GameObject coinPrefab;

    public float initialSpawnInterval = 3f; // Baþlangýç spawn aralýðý
    public float minSpawnInterval = 0.5f; // En düþük spawn aralýðý
    public float spawnIntervalDecreaseRate = 0.05f; // Zorluk seviyesinin azalma hýzý

    private float currentSpawnInterval; // Þu anki spawn aralýðý
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

            // Zorluk seviyesini artýrýn ve minSpawnInterval'i kontrol edin
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

        // Boþ kalan kýsma para prefabýný yerleþtir
        Instantiate(coinPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
