using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState gameState;

    private bool _executePlayingOnce = true;
    private bool _executeMenuOnce = true;
    private bool _executeDeathOnce = true;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.MainMenu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (gameState == GameState.InGame)
            {
                gameState = GameState.GameOver;
            }
        }
        
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
    }

    private void ExecutePlaying()
    {
        _executeDeathOnce = true;
        EnemySpawner.Instance.shouldSpawnEnemies = true;
    }

    private void ExecuteDeath()
    {
        _executeMenuOnce = true;
        EnemySpawner.Instance.shouldSpawnEnemies = false;
        EnemySpawner.Instance.DeleteEnemies();
        CanvasManager.Instance.gameCanvas.SetActive(false);
        CanvasManager.Instance.deathCanvas.SetActive(true);
    }
    
    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }
}
