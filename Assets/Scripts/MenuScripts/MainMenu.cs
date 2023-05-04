using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text creditsText;
    public Slider volSlider;
    public Text volText;

    //Function to hide or display the credits and volume slider based on the settings button being clicked
    public void SettingsButton()
    {
        if (!creditsText.IsActive())
        {
            creditsText.gameObject.SetActive(true);
            volSlider.gameObject.SetActive(true);
            volText.gameObject.SetActive(true);

        }
        else
        {
            creditsText.gameObject.SetActive(false);
            volSlider.gameObject.SetActive(false);
            volText.gameObject.SetActive(false);
        }
    }

}
