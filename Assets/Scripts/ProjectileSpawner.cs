using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Rigidbody prefab;
    Rigidbody[] pool;
    public int poolSize = 1000;

    void Awake ()
    {
        FillPool();
    }

    void FillPool()
    {
        pool = new Rigidbody[poolSize];
        for(int i = 0; i < poolSize; i ++)
        {
            Rigidbody bullet = Instantiate<Rigidbody>(prefab);
            pool[i] = bullet;
            bullet.gameObject.SetActive(false);
        }
    }

    public void Fire (Vector3 pos, Vector3 velocity)
    {
        Rigidbody projectile = null;
        for(int i = 0; i < poolSize; i ++)
        {
            Rigidbody p = pool[i];
            if (!p.gameObject.activeSelf)
            {
                projectile = p;
                break;
            }
        }

        if (projectile == null) return;

        projectile.gameObject.SetActive(true);
        projectile.position = pos;
        projectile.velocity = velocity;
    }
}
