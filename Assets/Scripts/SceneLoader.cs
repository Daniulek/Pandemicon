using System.Collections;
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
       SceneManager.LoadScene("Game");
        if (FindObjectOfType<GameSession>())
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
    }

    public void LoadTutorial()
    {

        SceneManager.LoadScene("Tutorial");
    }

    public void LoadCredits()
    {

        SceneManager.LoadScene("Credits");
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
