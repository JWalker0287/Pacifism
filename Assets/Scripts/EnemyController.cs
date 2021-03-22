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
        if (explosion == null) return;

        gameObject.SetActive(false);
        MultiplierSpawner.SpawnMultipliers(gameObject.transform.position);
        GameManager.ScorePoints(transform.position);

    }
}
    