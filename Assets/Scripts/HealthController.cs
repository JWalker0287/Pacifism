using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 1;
    int health;

    void OnEnable()
    {
        health = maxHealth;
    }

    void OnTriggerEnter(Collider c)
    {
        ExplosionController explosion = c.GetComponentInParent<ExplosionController>();
        BulletController bullet = c.GetComponentInParent<BulletController>();
        if (explosion == null && bullet == null) return;
        health--;
        if(health <= 0) Death();
    }

    void Death()
    {
        gameObject.SetActive(false);
        MultiplierSpawner.SpawnMultipliers(gameObject.transform.position);
        GameManager.ScorePoints(transform.position);
        AudioManager.Play("Pew");
    }
}
