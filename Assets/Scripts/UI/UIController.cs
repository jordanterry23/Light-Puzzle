using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public MainMenuUI mainMenuUI;
    public YouWinUI youWinUI;
    
    public GameManager gameManager;
    public int difficulty = 0;
    public int colorSelect = 0;

    public void StartButtonPressed(int diffValue, int colorValue)
    {
        difficulty = diffValue;
        colorSelect = colorValue;
        mainMenuUI.gameObject.SetActive(false);
        gameManager.StartGame(difficulty, colorValue);
    }

    public void RestartButtonPressed()
    {
        mainMenuUI.gameObject.SetActive(true);
        mainMenuUI.difficultyDrop.index = difficulty;
        gameManager.Reset();
        youWinUI.gameObject.SetActive(false);
    }

    public void Win()
    {
        youWinUI.gameObject.SetActive(true);
    }



}
