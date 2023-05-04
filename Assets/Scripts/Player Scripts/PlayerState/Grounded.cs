namespace PlayerState
{

    using UnityEngine;
    using System;

    public class Grounded : Base
    {
        //Movement speed whilst grounded
        public float speed = 10f;


        public Grounded(GameObject player) : base(player)
        {

        }

        public override void OnEnter()
        {
            //Set gravity scale to default value
            body.gravityScale = 4;
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

            //Update dashCooldown
            dashCooldown += Time.deltaTime;

            //Call animationHandler and Flip to update player sprite
            AnimationHandler();
            Flip();

            //return Grounded State
            return this;
        }

        public override State OnFixedUpdate()
        {
            if (!externalForce)
            {
                //If no external force is applied then move player horizontally based on input
                body.velocity = new Vector2(h * speed, body.velocity.y);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                //If space key pressed apply jump force and return new jumping state
                body.velocity = (new Vector2(body.velocity.x, speed * 1.3f));
                return new Jumping(player);
            }
            //Return grounded state
            return this;
        }

    }

}




