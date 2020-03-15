﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void LoadGameScene()
    {
        Debug.Log("Works!");
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {

        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {

        Application.Quit();

    }
}
