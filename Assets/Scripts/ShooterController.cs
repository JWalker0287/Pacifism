using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public static ProjectileSpawner bullets;
    public float shotDist = 28;
    public float chaseDist = 10;
    CharacterMotor motor;
    GunController gun;
    Animator anim;

    void Start()
    {
        motor = GetComponent<CharacterMotor>();
        gun = GetComponentInChildren<GunController>();
        //if (bullets = null)
       // {
            GameObject g = GameObject.Find("EnemyBullets");
            bullets = g.GetComponent<ProjectileSpawner>();
            Debug.Log("I Made It");
        //}
        gun.bullets = bullets;
    }

    void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //GetComponent<Animator>().Play("ShooterSpawn");
    }

    void Update()
    {
        Vector3 diff = PlayerController.player.transform.position - transform.position;
        float distSq = diff.sqrMagnitude;
        gun.shouldFire = distSq < shotDist * shotDist;
        if (distSq > chaseDist * chaseDist)
        {
            motor.dir = diff.normalized;
        }
        else
        {
            motor.dir *= 0.9f;
        }
        motor.lookDir = diff;
    }
    void OnTriggerEnter(Collider c)
    {
        ExplosionController explosion = c.GetComponentInParent<ExplosionController>();
        BulletController bullet = c.GetComponentInParent<BulletController>();
        if (explosion == null && bullet == null) return;

        gameObject.SetActive(false);
        MultiplierSpawner.SpawnMultipliers(gameObject.transform.position);
        GameManager.ScorePoints(transform.position);
        AudioManager.Play("Pew");
    }
}
