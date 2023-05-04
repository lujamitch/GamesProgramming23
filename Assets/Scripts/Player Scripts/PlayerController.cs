using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState.State state;
    public GameObject player;

    void Start()
    {
        //Set starting player state to grounded
        state = new PlayerState.Grounded(player);
    }

    //Every frame call handle new state to check for state transitions required onUpdate
    void Update()
    {
        HandleNewState(state.OnUpdate(), state);
    }

    //Call handle new state to check for state transitions required onFixedUpdate
    void FixedUpdate()
    {
        HandleNewState(state.OnFixedUpdate(), state);
    }

    //Set external force function to alter variable (used by bouncepads)
    public void SetExternalForce(bool value)
    {
        state.SetExternalForce(value);
    }

    //Function to change state if required
    void HandleNewState(PlayerState.State newState, PlayerState.State oldState)
    {
        if (newState != oldState)
        {
            //If new state required then change state and call onEnter of new state
            state = newState;
            state.OnEnter();
        }
    }


}
