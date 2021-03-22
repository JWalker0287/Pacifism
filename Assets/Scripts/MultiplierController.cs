using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class MultiplierController : MonoBehaviour
{
    CharacterMotor motor;
    public float minDist = 10;
    void Awake()
    {
        motor = GetComponent<CharacterMotor>();
    }
    void Update()
    {
        Vector3 diff = PlayerController.player.transform.position - transform.position;
        float distSq = diff.sqrMagnitude;
        if (distSq < minDist * minDist)
        {
            motor.dir = diff/ Mathf.Sqrt(distSq);
        }
    }
    void OnTriggerEnter(Collider c)
    {
        PlayerController player = c.GetComponentInParent<PlayerController>();
        if (player == null) return;
        gameObject.SetActive(false);
        GameManager.AddMultiplier(transform.position);
    }
}
