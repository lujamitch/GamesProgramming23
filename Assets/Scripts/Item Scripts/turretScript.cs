using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class turretScript : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject bullet;
    public float FireRate;
    private float nextTimeToShoot = 0;
    private Transform Shootpoint;
    public float Force;
    private AudioSource sfx;

    void Start()
    {
        //Initialise turret position and turret sound effect
        Shootpoint = GetComponent<Transform>();
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Set player position
        Vector2 targetPos = Target.position;
        //Calculate direction vector to aim with
        Direction = targetPos - (Vector2)transform.position;
        //Initialise detection range of turret
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        //If the RayCast detects an object
        if (rayInfo) 
        {
            //If this object is the player
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    //If not previously detected set detected to true
                    Detected = true;
                }
            }
        }
        else
        {
            //Otherwise reset detected if player not in range
            if (Detected == true)
            {
                Detected = false;
            }
        }
        //If player is currently detected
        if (Detected)
        {
            //If the time since the last bullet shot is sufficient
            if(Time.time > nextTimeToShoot)
            {
                //Reset time to shoot
                nextTimeToShoot = Time.time + 3 / FireRate;
                //Play the shoot sound effect
                sfx.Play();
                //Call shoot function
                shoot();
            }
        }
    }
    void shoot()
    {
        //Create a new bullet object at the centre of the turret
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        //Add a force to the bullet in the direction of the player
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    //Function to aid visualisation of the range of the turret
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
