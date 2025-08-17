using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject victoryUI;

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        victoryUI.SetActive(false);
    }

    public void ShowVictory()
    {
        mainMenuUI.SetActive(false);
        victoryUI.SetActive(true);
    }

    public void OnClickPlay()
    {
        mainMenuUI.SetActive(false);
        GameManager.Instance.SetState(GameManager.GameState.Playing);
    }
}
