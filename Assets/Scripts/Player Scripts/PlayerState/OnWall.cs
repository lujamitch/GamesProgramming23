namespace PlayerState
{

    using UnityEngine;

    public class OnWall : Base
    {




        public OnWall(GameObject player) : base(player)
        {

        }

        public override void OnEnter()
        {
            //Remove gravity on player
            body.gravityScale = 0;
            //Set speed of player to 0
            body.velocity = Vector2.zero;
            //Load wall jump sound
            wallJumpSound = Resources.Load<AudioClip>("walljump");
        }

        public override State OnUpdate()
        {
            //If space key pressed
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Change player sprite to normal size
                    body.transform.localScale = new Vector2(0.5f, 0.5f);
                    //Apply wall jump force
                    body.velocity = new Vector2(-Mathf.Sign(body.transform.localScale.x) * 4, 12);
                    //Play wall jump sound
                    audioSrc.PlayOneShot(wallJumpSound);
                    //Return jumping state
                    return new Jumping(player);
                }
      
        
            //Increase dash cooldown
            dashCooldown += Time.deltaTime;

            //Call animation handler
            AnimationHandler();

            //Return OnWall State
            return this;
        }

        public override State OnFixedUpdate()
        {

            return this;
        }

    }

}
