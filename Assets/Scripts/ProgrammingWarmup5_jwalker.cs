using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class ProgrammingWarmup5_jwalker : MonoBehaviour
{
    public CharacterMotor motor;

    void Update()
    {
        motor.dir = new Vector3(Input.GetAxisRaw("HorizontalLeft"),0,Input.GetAxisRaw("VerticalLeft")).normalized;
        motor.lookDir = new Vector3(Input.GetAxisRaw("HorizontalRight"),0,Input.GetAxisRaw("VerticalRight")).normalized;
    }
}
