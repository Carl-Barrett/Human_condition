using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadMainMenu : MonoBehaviour
{
    public Button mainMenuButton;

    void Start()
    {
        // Assign the LoadMainMenu method to the OnClick event of the TMP button
        mainMenuButton.GetComponent<Button>().onClick.AddListener(LoadMainMenuScene);
    }

    void LoadMainMenuScene()
    {
        // Load the "Main Menu" scene
        SceneManager.LoadScene("main menu");
    }
}

