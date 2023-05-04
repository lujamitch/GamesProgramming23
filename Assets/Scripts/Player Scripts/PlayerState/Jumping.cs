namespace PlayerState
{
    using System.Collections;
    using UnityEngine;

    public class Jumping : Base
    {
        //Horizontal Speed
        public float speed = 10f;
        //In-Air speed reduction
        public float speedReduction = 0.8f;
        //Dash class
        private PlayerDash dashScript;
        //Time between dash button presses
        float doubleTapTime;
        //Last dash button pressed
        KeyCode lastKeyCode;


        public Jumping(GameObject player) : base(player)
        {
            dashScript = player.GetComponent<PlayerDash>();
        }

        public override void OnEnter()
        {
            if (!(dashScript.GetisDashing()) && !externalForce)
            {
                //If player is not dashing and no external force is applied then set gravity to default
                body.gravityScale = 4;
            }
            //Play player jump sound
            jumpSound = Resources.Load<AudioClip>("jump");
            audioSrc.PlayOneShot(jumpSound);

            //Set the hasDashed bool to false (Player can only dash once per jump)
            hasDashed = false;
        }

        public override State OnUpdate()
        {
            //Get horizontal input
            h = Input.GetAxisRaw("Horizontal");

            //If player is falling increase gravity
            if (body.velocity.y < 0)
            {
                body.gravityScale = 6f;
            }

            //If the player has not already dashed this jump
            if (!hasDashed)
            {
                //If A is pressed
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //If the time since last A pressed is greater than the double tap time, the last key pressed was also A and the dashCooldown is sufficient
                    if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A && dashCooldown > 0.2f)
                    {
                        //Reset dashCooldown
                        dashCooldown = 0f;
                        //Set the hasDashed to true
                        hasDashed = true;
                        //Call the dashFunction to dash left
                        dashScript.CallDash(-1f);
                    }
                    else
                    {
                        //Otherwise increase double tap time
                        doubleTapTime = Time.time + 1f;
                    }
                    //Set last key pressed to A
                    lastKeyCode = KeyCode.A;
                }

                //If D is pressed
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //If the time since last D pressed is greater than the double tap time, the last key pressed was also D and the dashCooldown is sufficient
                    if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D && dashCooldown > 0.2f)
                    {
                        //Reset dashCooldown
                        dashCooldown = 0f;
                        //Set the hasDashed to true
                        hasDashed = true;
                        //Call the dashFunction to dash right
                        dashScript.CallDash(1f);
                    }
                    else
                    {
                        //Otherwise increase double tap time
                        doubleTapTime = Time.time + 1f;
                    }

                    //Set last key pressed to A
                    lastKeyCode = KeyCode.D;
                }
            }

            //Call animationHandler and Flip to update player sprite
            AnimationHandler();
            Flip();

            //Set the isDashing bool to the correct value
            isDashing = dashScript.GetisDashing();
            
            //Increase dashCooldown
            dashCooldown += Time.deltaTime;

            //Return player jumping state
            return this;
        }

        public override State OnFixedUpdate()
        {
            //If player is not dashing and no external force is applied
            if (!isDashing && !externalForce)
            {
                //Move player horizontally with reduced speed
                body.velocity = new Vector2(h * speed * speedReduction, body.velocity.y);
            }
            
            //If player is detected to be grounded return new Grounded state
            if (isGrounded())
            {
                return new Grounded(player);
            }

            //If player is detected to be on wall then return new OnWall state
            if (onWall())
            {
                return new OnWall(player);
            }

            //Return jumping state
            return this;
        }



    }

    

}