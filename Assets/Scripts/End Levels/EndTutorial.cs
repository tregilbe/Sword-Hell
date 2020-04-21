using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the game object that entered the trigger is our player, then load the next level.
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
    }
}
