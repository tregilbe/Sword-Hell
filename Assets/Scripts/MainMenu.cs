﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.enemiesList.Clear();
        GameManager.instance.spawnersList.Clear();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.instance.currentScene += 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(sceneName: "Tutorial");
    }
}
