using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMenuLoader : MonoBehaviour
{
    private void OnEnable()
    {
        //When cutscene SceneLoader is Enabled on final cutscene load the menu scene
        SceneManager.LoadScene("MenuScene");
    }
}
