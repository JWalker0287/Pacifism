using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class EnemyController : MonoBehaviour
{
    CharacterMotor motor;
    void Awake()
    {
        motor = GetComponent<CharacterMotor>();
    }
    void Update()
    {
        
        motor.dir = (PlayerController.player.transform.position - transform.position).normalized;
      
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
    void OnEnable()
    {
        StartCoroutine(SpawningIn());
        GetComponent<Animator>().Play("EnemySpawn");
    }

    IEnumerator SpawningIn ()
    {
        motor.enabled = false;
        yield return new WaitForSeconds(0.5f);
        motor.enabled = true;
    }
    void OnCollisionEnter(Collision c)
    {
        PlayerController p = c.gameObject.GetComponent<PlayerController>();
        if (p == null) return;

        PlayerController.player.Death();

    }
}
    