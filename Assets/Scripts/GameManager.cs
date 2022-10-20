using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState gameState;

    public GameObject playerPrefab;
    
    private bool _executePlayingOnce = true;
    private bool _executeMenuOnce = true;
    private bool _executeDeathOnce = true;
    private int _score;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstLaunch") == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("FirstLaunch", 1);
        }
        
        Instance = this;
        gameState = GameState.MainMenu;
    }

    private void Update()
    {   
        switch (gameState)
        {
            case GameState.MainMenu:
                if (_executeMenuOnce)
                {
                    ExecuteMenu();
                    _executeMenuOnce = false;
                }
                break;
            case GameState.InGame:
                if (_executePlayingOnce)
                {
                    ExecutePlaying();
                    _executePlayingOnce = false;
                }
                break;
            case GameState.GameOver:
                if (_executeDeathOnce)
                {
                    ExecuteDeath();
                    _executeDeathOnce = false;
                }
                break;
            default:
                break;
        }
    }

    private void ExecuteMenu()
    {
        _executePlayingOnce = true;
        _score = 0;
        CanvasManager.Instance.UpdateGameScore(_score);
    }

    private void ExecutePlaying()
    {
        _executeDeathOnce = true;
        SpawnPlayer();
        EnemySpawner.Instance.shouldSpawnEnemies = true;
    }

    private void ExecuteDeath()
    {
        _executeMenuOnce = true;
        DeletePlayer();
        EnemySpawner.Instance.shouldSpawnEnemies = false;
        EnemySpawner.Instance.DeleteEnemies();
        CanvasManager.Instance.DisplayDeathScores(_score, PlayerPrefs.GetInt("highestScore"));
        CanvasManager.Instance.gameCanvas.SetActive(false);
        CanvasManager.Instance.deathCanvas.SetActive(true);
    }

    public void AddScore()
    {
        _score += 300;
        CanvasManager.Instance.UpdateGameScore(_score);
    }
    
    private void SpawnPlayer()
    {
        GameObject thisPlayer = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void DeletePlayer()
    {
        GameObject thisPlayer = GameObject.FindGameObjectWithTag("Player");
        Destroy(thisPlayer);
    }

    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }
}
