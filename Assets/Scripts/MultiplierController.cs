using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class MultiplierController : MonoBehaviour
{
    CharacterMotor motor;
    public float minDist = 10;
    public float timeBeforeDisable = 10;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        motor = GetComponent<CharacterMotor>();
    }
    void OnEnable ()
    {
        anim.SetTrigger("TimeOut");
        StartCoroutine(DeSpawnMultiplier());
    }
    IEnumerator DeSpawnMultiplier ()
    {
        yield return new WaitForSeconds(timeBeforeDisable);
        gameObject.SetActive(false);
    }
    void Update()
    {
        Vector3 diff = PlayerController.player.transform.position - transform.position;
        float distSq = diff.sqrMagnitude;
        if (distSq < minDist * minDist)
        {
            motor.dir = diff/ Mathf.Sqrt(distSq);
        }
        else
        {
            motor.dir = Vector3.zero;
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
