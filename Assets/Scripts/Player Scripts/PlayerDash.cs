using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    //Variables required for playerDash action
    private Rigidbody2D body;
    private bool isDashing;
    private float dashDistance = 15f;
    private AudioClip airdashSound;
    private AudioSource audiosrc;


    private void Start()
    {
        //Get player body
        body = GetComponent<Rigidbody2D>();
        //Set isDashing bool to false
        isDashing = false;
        //Load airdash sound and get audiosource output
        airdashSound = Resources.Load<AudioClip>("airdash");
        audiosrc = GetComponent<AudioSource>();
    }

    //Public function to be called to start dash coroutine
    public void CallDash(float direction)
    {
        StartCoroutine(Dash(direction));
    }

    //Function to return the isDashing bool
    public bool GetisDashing()
    {
        return isDashing;
    }

    //Function to perform player dash
    private IEnumerator Dash(float direction)
    {
        //Play the air dash sounds
        audiosrc.PlayOneShot(airdashSound);
        //Set isDashing to true
        isDashing = true;
        //Remove gravity from body
        body.gravityScale = 0;
        //Remove vertical velocity
        body.velocity = new Vector2(body.velocity.x, 0f);
        //Apply horizontal force based on direction
        body.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        //Wait 0.4 seconds
        yield return new WaitForSeconds(0.4f);
        //Reset bool and restore gravity scale
        isDashing = false;
        body.gravityScale = 4;
    }
}
