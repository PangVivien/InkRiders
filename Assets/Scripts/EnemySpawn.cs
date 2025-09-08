using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab1;  // First enemy type
    public GameObject enemyPrefab2;  // Second enemy type
    public float delayBetweenWaves = 5f;  // Time after both enemies before next loop
    public float delayBetweenEnemies = 3f; // Time between Enemy1 and Enemy2

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true) // infinite loop
        {
            // Spawn Enemy 1
            Instantiate(enemyPrefab1, transform.position, transform.rotation);

            // Wait before spawning Enemy 2
            yield return new WaitForSeconds(delayBetweenEnemies);

            // Spawn Enemy 2
            Instantiate(enemyPrefab2, transform.position, transform.rotation);

            // Wait before repeating the whole cycle
            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }
}
