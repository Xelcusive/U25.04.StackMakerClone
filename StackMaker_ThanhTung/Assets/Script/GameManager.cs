using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton
    public enum GameState { Menu, Playing, Victory }
    public GameState gameState;

    public LevelManager levelManager;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Không xóa khi load scene
    }

    void Start()
    {
        SetState(GameState.Menu);
    }

    public void SetState(GameState newState)
    {
        gameState = newState;
        Debug.Log("Trạng thái game: " + gameState);

        switch (gameState)
        {
            case GameState.Menu:
                // Mở UI menu
                break;
            case GameState.Playing:
                levelManager.InitLevel();
                break;
            case GameState.Victory:
                // Mở UI Victory
                break;
        }
    }
}
