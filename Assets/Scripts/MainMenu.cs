using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickToStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickToQuitGame()
    {
        Debug.Log("Game Quit!!!");
        Application.Quit();
    }

    public void ClickToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickToScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickToScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void ClickToScene3()
    {
        SceneManager.LoadScene(3);  
    }
}
