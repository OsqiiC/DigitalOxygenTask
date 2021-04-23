using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public int enemyCounter = 0;

    [SerializeField] private int spawnChance;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnEnemy();
    }

    /// <summary>
    /// Spawning an enemy at specifc point
    /// </summary>
    private void SpawnEnemy()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            //Chance of spawn
            if (Random.Range(0, 100) < spawnChance)
            {
                enemyCounter++;
                Instantiate(enemyPrefab, spawnPoints[i].position,Quaternion.identity);
            }
        }
    }
}
