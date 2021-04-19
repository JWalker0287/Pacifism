using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    void Awake()
    {
        Button selectedButton = GetComponentInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
    }
}
