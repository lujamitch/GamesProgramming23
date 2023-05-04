using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private SceneController sceneController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If collision is player
        if (other.CompareTag("Player"))
        {
            //Call sceneController to load the next scene
            sceneController = GetComponent<SceneController>();
            sceneController.NextScene();
        }
    }

}
