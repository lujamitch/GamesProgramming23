using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    //Access the game over screen script
    public GameObject GameOver;

    //If the bullet collides with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Get the gameover component from the time controller and call game over
            GameOver = GameObject.Find("TimeController");
            GameOver.GetComponent<CountdownTimer>().CallGameOver();

        }
        //Destroy the bullet on collision with any game object
        Destroy(this.gameObject);
    }
}
