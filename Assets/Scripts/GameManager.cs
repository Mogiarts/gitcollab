using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameState _gameState;

    private void Awake()
    {
        Instance = this;
        _gameState = GameState.InGame;
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.MainMenu:
                break;
            case GameState.InGame:
                
                break;
            case GameState.GameOver:
                break;
            default:
                break;
        }
    }

    private void ExecutePlaying()
    {
        EnemySpawner.Instance.shouldSpawnEnemies = true;
    }
    
    private enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }
}
