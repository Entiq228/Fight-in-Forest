using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private static EnemySpawner instance;
    [SerializeField] private void Awake() { instance = this; }
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnInterval = 2f;

    public void StartSpawning()
    {
        StartCoroutine(SpawnDeley());
    }
    IEnumerator SpawnDeley()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDeley());
    }
    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);
        GameObject SpawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);
    }
}
