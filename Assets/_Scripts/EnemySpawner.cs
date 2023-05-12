using System.Collections;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawn[] enemySpawns;

    private void Start()
    {
        foreach (EnemySpawn enemySpawn in enemySpawns)
        {
            StartCoroutine(SpawnEnemy_Coroutine(enemySpawn));
        }
    }

    private IEnumerator SpawnEnemy_Coroutine(EnemySpawn enemySpawn)
    {
        while (true)
        {
            Transform spawnPoint = enemySpawn.SpawnPoints[Random.Range(0, enemySpawn.SpawnPoints.Length)];
            Instantiate(enemySpawn.Prefab, spawnPoint.position, Quaternion.identity);

            yield return new WaitForSeconds(enemySpawn.SpawnDelay);
        }
    }
}

[System.Serializable]
public struct EnemySpawn
{
    public GameObject Prefab;
    public float SpawnDelay;
    public Transform[] SpawnPoints;
}
