using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour
{
    public static MultiplierSpawner spawner;
    public MultiplierController prefab;
    MultiplierController[] pool;
    public int poolSize = 100;
    public int multipliersPerSpawn;

    void Awake()
    {
        spawner = this;
        FillPool();
    }
    void FillPool()
    {
        pool = new MultiplierController[poolSize];
        for (int i = 0; i < poolSize; i ++)
        {
            MultiplierController multiplier = Instantiate<MultiplierController>(prefab);
            pool[i] = multiplier;
            multiplier.gameObject.SetActive(false);
            multiplier.transform.SetParent(transform);
        }
    }

    MultiplierController SpawnMultiplier()
    {
        for (int i = 0; i < poolSize; i++)
        {
            MultiplierController multiplier = pool[i];
            if (!multiplier.gameObject.activeSelf) return multiplier;
        }
        return null;
    }
    public static void SpawnMultipliers (Vector3 pos)
    {
        for (int i = 0; i < spawner.multipliersPerSpawn; i ++)
        {
            MultiplierController multiplier = spawner.SpawnMultiplier();
            if (multiplier == null) return;
            Vector3 rand = Random.insideUnitSphere * 2;
            rand.y = 0;
            multiplier.transform.position = pos + rand;
            multiplier.gameObject.SetActive(true);
        }
    }
}
