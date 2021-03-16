using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour
{
    CharacterMotor motor;
    void Awake()
    {
        motor = GetComponent<CharacterMotor>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        motor.dir = new Vector3(x,0,z).normalized;
    }
}
