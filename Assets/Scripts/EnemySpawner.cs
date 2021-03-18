using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController prefab;
    EnemyController[] pool;
    public int poolSize = 100;
    public int spawnCount = 3;
    public float spawnInterval = 3;
    public Transform[] spawnPoints;
    IEnumerator Start()
    {
        FillPool();
        while (enabled)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemies();
        }
    }
    void FillPool ()
    {
        pool = new EnemyController[poolSize];
        for (int i = 0; i < poolSize; i ++)
        {
            EnemyController enemy = Instantiate<EnemyController>(prefab);
            pool[i] = enemy;
            enemy.gameObject.SetActive(false);
            enemy.transform.SetParent(transform);
        }
    }
    EnemyController SpawnEnemy ()
    {
        for (int i = 0;i < poolSize;i ++)
        {
            EnemyController enemy = pool[i];
            if (!enemy.gameObject.activeSelf)
            {
                return enemy;
            }
        }
        return null;
    }
    void SpawnEnemies ()
    {
        Transform t = spawnPoints[Random.Range(0,spawnPoints.Length)];
        for (int i = 0; i < spawnCount; i ++)
        {
            EnemyController enemy = SpawnEnemy();
            Vector3 rand =  Random.insideUnitSphere * 5;
            rand.y = 0;
            enemy.transform.position = t.position + rand;
            enemy.gameObject.SetActive(true);
        }
    }
}
