using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void OpenWebPage()
    {
        Application.OpenURL("URL");
    }
}
