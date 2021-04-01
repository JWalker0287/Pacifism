using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadShooter()
    {
        SceneManager.LoadScene("Shooter");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
