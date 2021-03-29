using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CharacterMotor))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    CharacterMotor motor;
    void Awake()
    {
        player = this;
        motor = GetComponent<CharacterMotor>();
        GetComponent<Animator>().Play("PlayerStart");
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        motor.dir = new Vector3(x,0,z).normalized;
        if (Input.GetButtonDown("Cancel")) SceneManager.LoadScene("MainMenu");
    }
    void OnCollisionEnter(Collision c)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
