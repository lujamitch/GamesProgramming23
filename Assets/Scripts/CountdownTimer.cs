using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    //Get level's time limit
    public float maxTime;
    public GameOver GameOver;


    public Text timerText;
    
    

    private void Start()
    {
        //Set current time to max time and set the timer's status to running
        currentTime = maxTime;
        runningTimer = true;
    }

    private void FixedUpdate()
    {
        //Subtract the cange in time since the last fixed update from current time
        currentTime -= Time.deltaTime;
        //Change the timer's text to the rounded value of currentTime
        timerText.text = "Time: " + System.Math.Round(currentTime,0);

        //If remaining seconds is less than 15 change the text to red
        if (currentTime <= 15)
        {
            timerText.color = Color.red;
        }

        //If time has run out 
        if (currentTime <= 0)
        {
            //Set timer to not running and call gameover screen
            runningTimer = false;
            GameOver.Setup();
        }
    }

    private void Update()
    {
        //If the player pressed the escape key then call game over screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver.Setup();
        }
    }

    //Function for the bullet class to call GameOver
    public void CallGameOver()
    {
        GameOver.Setup();
    }
}
