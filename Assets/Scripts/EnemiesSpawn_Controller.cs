using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn_Controller : MonoBehaviour
{
    public bool canSpawn = true; // 1
    public GameObject EnemyPrefab; // 2
    public List<Transform> EnemiesSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns_Min;
    public float timeBetweenSpawns_Max;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = EnemiesSpawnPositions[Random.Range(0,
       EnemiesSpawnPositions.Count)].position; // 1
        GameObject enemy = Instantiate(EnemyPrefab, randomPosition,
       EnemyPrefab.transform.rotation); // 2
        //enemy.GetComponent<Enemy>().SetSpawner(this); // 4
    }

    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnEnemy(); // 3
            yield return new WaitForSeconds(Random.Range(timeBetweenSpawns_Min, timeBetweenSpawns_Max)); // 4
        }
    }
}
