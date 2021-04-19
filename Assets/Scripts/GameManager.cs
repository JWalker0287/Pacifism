using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public string gameName = "Pacifism";
    public int points;
    public int multiplier;
    public Text pointsText;
    public Text multiplierText;
    public Text highScoreText;
    public bool started = false;
    public bool gameOver = false;
    public GameObject pauseMenu;

    void Awake()
    {
        game = this;
        pauseMenu.SetActive(false);
        UpdateScoreUI();
    }
    public static void ScorePoints(Vector3 pos)
    {
        int points = 26 * game.multiplier;
        game.points += points;
        TextSpawner.Spawn(points.ToString(), pos);
        game.UpdateScoreUI();
    }

    public static void AddMultiplier(Vector3 pos)
    {
        game.multiplier ++;
        game.UpdateScoreUI();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }
    void UpdateScoreUI()
    {
        multiplierText.text = "x" + multiplier.ToString();
        pointsText.text = points.ToString() + " pts";

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScoreText.text = "HI: " + highScore.ToString();
    }
    public static void Death()
    {
        if (game.gameOver) return;
        game.StartCoroutine(game.DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        PlayerController.player.playerVisuals.SetActive(false);
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.04f;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseResume()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Button selectedButton = GetComponentInChildren<Button>();
            EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
        }
    }
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void FullQuit()
    {
        Application.Quit();
    }
}
