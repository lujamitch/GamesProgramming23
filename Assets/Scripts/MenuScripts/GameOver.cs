using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private AudioSource audiosrc;

    //Function to display game over screen
    public void Setup()
    {
        //Set time scale to 0
        Time.timeScale = 0;
        //Set singleton paused value to true (locking all player animation)
        Paused.instance.paused = true;
        //Display game over screen
        gameObject.SetActive(true);
        //Get and play death sound
        audiosrc = GetComponent<AudioSource>();
        audiosrc.Play();
    }

    //Function for Restart Button to reload scene
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Function for main menu button to load main menu scene
    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
