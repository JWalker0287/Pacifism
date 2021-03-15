using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector3(x,0,z).normalized * speed;
    }
}
