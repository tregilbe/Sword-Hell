using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        GameManager.instance.currentScene = 0;
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
