using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    CharacterMotor motor;
    void Awake()
    {
        player = this;
        motor = GetComponent<CharacterMotor>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        motor.dir = new Vector3(x,0,z).normalized;
    }
}
