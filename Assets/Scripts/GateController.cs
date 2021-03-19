using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Transform left;
    public Transform right;
    void OnTriggerEnter(Collider c)
    {
        ExplosionSpawner.SpawnExplosion(left.position);
        ExplosionSpawner.SpawnExplosion(right.position);
        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Game Over");
    }
}