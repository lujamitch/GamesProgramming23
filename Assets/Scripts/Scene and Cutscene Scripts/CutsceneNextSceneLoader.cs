using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneNextSceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        //When cutscene Scene Loader is enabled load next scene in buildindex
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
