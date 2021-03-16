using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class EnemyController : MonoBehaviour
{
    static PlayerController player;
    CharacterMotor motor;
    void Awake()
    {
        motor = GetComponent<CharacterMotor>();
        if (player == null) player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        
        motor.dir = (player.transform.position - transform.position).normalized;
      
    }
}
    