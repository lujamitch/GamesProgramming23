using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Get player object, the desired camera offset and the smoothness of the camera's movement to the offset
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    //Reposition camera based on player movement
    void FixedUpdate()
    {
        //Get player position
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        //If player is facing right
        if (player.transform.localScale.x > 0f)
        {
            //Get camera position of player position + offset
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y + 1, playerPosition.z);
        }
        //If player is facing left
        else
        {
            //Get camera position of player position - offset
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y + 1, playerPosition.z);
        }

        //Linearlly interpolate camera position from current to desired position
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
