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

        GetComponent<Animator>().Play("GateSpawn");
    }
    void OnTriggerEnter(Collider c)
    {
        PlayerController p = c.gameObject.GetComponent<PlayerController>();
        if (p == null) return;

        ExplosionSpawner.SpawnExplosion(left.position);
        ExplosionSpawner.SpawnExplosion(right.position);
        AudioManager.Play("Explosion");
        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Game Over");
    }
}