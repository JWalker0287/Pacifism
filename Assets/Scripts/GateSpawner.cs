using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    public GateController prefab;
    GateController[] pool;
    public int poolSize = 100;
    public float spawnInterval = 3;
    public Bounds range = new Bounds(Vector3.zero, new Vector3(50,0,50));
    IEnumerator Start()
    {
        FillPool();
        while (enabled)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnGate();
        }
    }
    void FillPool ()
    {
        pool = new GateController[poolSize];
        for (int i = 0; i < poolSize; i ++)
        {
            GateController gate = Instantiate<GateController>(prefab);
            pool[i] = gate;
            gate.gameObject.SetActive(false);
            gate.transform.SetParent(transform);
        }
    }
    void SpawnGate ()
    {
        GateController gate = null;
        for (int i = 0;i < poolSize;i ++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                gate = pool[i];
                break;
            }
        }
        if (gate == null) return;

        Vector3 rand =  new Vector3(
            Random.Range(-range.extents.x, range.extents.x),
            0,
            Random.Range(-range.extents.z, range.extents.z)
        );
        gate.transform.position = transform.position + rand;
        gate.gameObject.SetActive(true);
    }
    void OnDrawGizmos ()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(range.center, range.size);
    }
}