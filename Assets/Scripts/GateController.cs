using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Transform left;
    public Transform right;
    void OnEnable()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        Vector3 v = Random.insideUnitSphere;
        v.y=0;
        body.velocity = v;
        body.angularVelocity = Vector3.up * Random.Range(-0.5f, 0.5f);
    }
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