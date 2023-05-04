using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//State interface for player states. Declares functions of states.

namespace PlayerState
{
    public interface State
    {

        //Function called when state is entered initially
        void OnEnter();

        //Function called each frame (returns State)
        State OnUpdate();

        //Function called at a fixed interval (Returns State)
        State OnFixedUpdate();

        //Function called to flip the player sprite based on direction facing
        void Flip();

        //Function called to set the ExternalForce variable to prevent player input
        public void SetExternalForce(bool value);


        //Function handling player sprite animation
        void AnimationHandler();


        //Function to determine is player is grounded
        bool isGrounded();


        //Function to determine of the player is making contact with a wall
        bool onWall();




    }
}
