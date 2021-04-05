using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    GameObject[] pool;
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
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i ++)
        {
            GameObject enemy = Instantiate<GameObject>(prefab);
            pool[i] = enemy;
            enemy.gameObject.SetActive(false);
            enemy.transform.SetParent(transform);
        }
    }
    GameObject SpawnEnemy ()
    {
        for (int i = 0;i < poolSize;i ++)
        {
            GameObject enemy = pool[i];
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
            GameObject enemy = SpawnEnemy();
            if (enemy == null) return;
            Vector3 rand =  Random.insideUnitSphere * 5;
            rand.y = 0;
            enemy.transform.position = t.position + rand;
            enemy.gameObject.SetActive(true);
        }
        
    }
}
