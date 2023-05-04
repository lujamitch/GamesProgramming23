using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadController : MonoBehaviour
{
    //Initialise bounce pad variables
    public int direction;
    public float bounce = 20f;
    private Animator anim;
    private AudioSource sfx;

    //Detects collision with players
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Get and play bounce pad animation
            anim = GetComponent<Animator>();
            anim.Play("bouncepadActive");
            //Get and play BouncePad sound
            sfx = GetComponent<AudioSource>();
            sfx.Play();
            //Call External force function
            StartCoroutine(ExternalForce(collision));
        }
    }

    //Function to apply force to player, suspend time and disable player input for that time
    private IEnumerator ExternalForce(Collision2D collision)
    {
        //Set external force variable in player which disables movement input
        collision.gameObject.GetComponent<PlayerController>().SetExternalForce(true);

        //Options to determine which direction to propell the player in
        switch (direction)
        {
            case 1:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * bounce, ForceMode2D.Impulse);
                break;
            case 2:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.up * bounce, ForceMode2D.Impulse);
                break;
            case 3:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * bounce, ForceMode2D.Impulse);
                break;
            case 4:
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * bounce, ForceMode2D.Impulse);
                break;
        }
        //Wait to allow the player to move in the desired direction without interruption
        yield return new WaitForSeconds(0.3f);
        //Return to original bounce pad animation
        anim.Play("BouncePad");
        //Disable external force lock on player movement
        collision.gameObject.GetComponent<PlayerController>().SetExternalForce(false);
    }
}
