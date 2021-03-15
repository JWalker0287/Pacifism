using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    public float turnSpeed = 20;
    Rigidbody body;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x,0,z).normalized;
        body.velocity = new Vector3(x,0,z).normalized * speed;

        if (body.velocity.sqrMagnitude > 0.1f)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * turnSpeed);
        }
    }
}
