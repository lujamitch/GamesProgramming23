using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base state for other states to reference/override

namespace PlayerState
{

    using UnityEngine;


    public abstract class Base : State
    {
        //Player object
        protected GameObject player;
        //Player body
        protected Rigidbody2D body;
        //Player controller class
        protected PlayerController playerController;
        //Player animator
        protected Animator anim;
        //Layers required by the isGrounded and onWall functions
        [SerializeField] protected LayerMask groundLayer;
        [SerializeField] protected LayerMask wallLayer;
        //Players collider required by the isGrounded and onWall functions
        protected CapsuleCollider2D capsuleCollider;
        //Horizontal input float
        protected float h;
        //External force variable
        protected bool externalForce = false;
        //Dashing variables
        protected float dashCooldown;
        protected bool isDashing;
        protected bool hasDashed;
        //Audio clips and sources required
        public static AudioClip jumpSound, wallJumpSound;
        protected AudioSource audioSrc;

        public Base(GameObject player)
        {
            //Initialisation of variables 
            this.player = player;
            this.playerController = player.GetComponent<PlayerController>();
            this.body = player.GetComponent<Rigidbody2D>();
            this.anim = player.GetComponent<Animator>();
            this.capsuleCollider = player.GetComponent<CapsuleCollider2D>();
            this.groundLayer = LayerMask.GetMask("Ground");
            this.wallLayer = LayerMask.GetMask("Wall");
            this.isDashing = player.GetComponent<PlayerDash>().GetisDashing();
            this.audioSrc = player.GetComponent<AudioSource>();

        }

        public virtual void OnEnter()
        {

        }

        public virtual State OnUpdate()
        {
            return this;
        }

        public virtual State OnFixedUpdate()
        {
            return this;
        }

        //Player flip functoin
        public virtual void Flip()
        {
            if (!Paused.instance.paused)
            {
                if (h < -0.01f)
                {
                    //If facing left then flip player sprite
                    body.transform.localScale = new Vector2(-0.5f, 0.5f);
                }
                if (h > 0.01f)
                {
                    //If facing right then flip player sprite
                    body.transform.localScale = new Vector2(0.5f, 0.5f);
                }
            }
        }

        //Set the external force variable to a given value
        public virtual void SetExternalForce(bool value)
        {
            externalForce = value;
        }

        public virtual void AnimationHandler()
        {
            if (!Paused.instance.paused)
            {
                //Set animation parameters for animation controller
                anim.SetBool("run", h != 0);
                anim.SetBool("rising", body.velocity.y > 0);
                anim.SetBool("falling", body.velocity.y < 0);
                anim.SetBool("grounded", isGrounded());
                anim.SetBool("dashing", isDashing);
                anim.SetBool("wall", onWall());
            }
        }

        public virtual bool isGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
            //If raycast comes into contact with the ground layer and isnt null return true 
            return raycastHit.collider != null;
        }

        public virtual bool onWall()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(body.transform.localScale.x, 0), 0.2f, wallLayer);
            //If raycast comes into contact with the wall layer and isnt null return true 
            return raycastHit.collider != null;
        }

    }

}