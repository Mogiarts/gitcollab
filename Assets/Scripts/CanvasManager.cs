using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    public GameObject gameCanvas;
    public GameObject menuCanvas;
    public GameObject deathCanvas;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI sessionScore;
    public TextMeshProUGUI highestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateGameScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void MainMenuButton()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }

    public void DeathMenuButton()
    {
        deathCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        GameManager.Instance.gameState = GameManager.GameState.MainMenu;
    }

    public void DisplayDeathScores(int a, int b)
    {
        sessionScore.text = a.ToString();
        highestScore.text = b.ToString();    
    }
}
