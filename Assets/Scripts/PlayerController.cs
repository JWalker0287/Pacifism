using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 20;
    public float maxVelocityChange = 1;
    Rigidbody body;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    Vector3 dir;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        dir = new Vector3(x,0,z).normalized;
        
        if (body.velocity.sqrMagnitude > 0.1f)
        {
            transform.forward = Vector3.Lerp(
                transform.forward, 
                dir, 
                Time.deltaTime * turnSpeed
            );
        }
    }
    void FixedUpdate ()
    {
        Vector3 velocityChange = dir * speed - body.velocity;
        velocityChange.y = 0;
        if (velocityChange.magnitude > maxVelocityChange)
        {
            velocityChange = velocityChange.normalized * maxVelocityChange;
        }
        body.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
