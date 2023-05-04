using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameOver GameOver;
    private AudioSource sfx;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If collision detected is with player
        if (other.CompareTag("Player"))
        {
            //Play death sound and display GameOver screen
            sfx = GetComponent<AudioSource>();
            sfx.Play();
            GameOver.Setup();
        }
    }
}
