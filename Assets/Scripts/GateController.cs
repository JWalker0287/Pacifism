using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Explode");
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Game Over");
    }
}