using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Singleton class to be accessible by all classes of the game
public class Paused : MonoBehaviour
{
    public static Paused instance;

    //Status of the game (if it is paused or not)
    [HideInInspector]
    public bool paused = false;

    private void Awake()
    {
        CreateSingleton();
    }

    //Creation of the singleton
    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
