using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public static TextSpawner spawner;
    public TextMesh prefab;
    public TextMesh[] pool;
    public int poolSize = 100;

    void Awake()
    {
        spawner = this;
        FillPool();
    }
    void FillPool()
    {
        pool = new TextMesh[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            TextMesh m = Instantiate<TextMesh>(prefab);
            pool[i] = m;
            m.gameObject.SetActive(false);
        }
    }
    
    TextMesh Spawn()
    {
        for (int i = 0; i < poolSize; i ++)
        {
            TextMesh m = pool[i];
            if (!m.gameObject.activeSelf) return m;
        }
        return null;
    }

    public static void Spawn (string text, Vector3 pos)
    {
        TextMesh m = spawner.Spawn();
        if (m == null) return;

        m.text = text;
        m.transform.position = pos;
        m.gameObject.SetActive(true);
    }
}
