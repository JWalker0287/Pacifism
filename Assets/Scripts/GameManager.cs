using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public int points;
    public int multiplier;
    public Text pointsText;
    public Text multiplierText;
    public Text highScoreText;

    void Awake()
    {
        game = this;
        UpdateScoreUI();
    }
    public static void ScorePoints(Vector3 pos)
    {
        game.points += 25 * game.multiplier;
        game.UpdateScoreUI();
    }

    public static void AddMultiplier(Vector3 pos)
    {
        game.multiplier ++;
        game.UpdateScoreUI();
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
}