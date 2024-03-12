using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static int totalLevels = 2;
    private static int currentLevel;
    public void StartGame()
    {
        currentLevel = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > totalLevels)
        {
            SceneManager.LoadScene("End Screen");
        }
        else
        {
            ItemCollector.collectedGems = 0;
            ItemCollector.collectedCherries = 0;
            SceneManager.LoadScene("Level " + currentLevel);
        }
    }

    public void RestartLevel()
    {
        ItemCollector.collectedGems = 0;
        ItemCollector.collectedCherries = 0;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
