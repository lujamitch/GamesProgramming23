using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer master;

    //Set the game volume based on previously saved preference
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    //Set the overall game volume
    public void SetVolume(float value)
    {
        if (value < 1)
        {
            value = .001f;
        }
        //Get sliders current value
        RefreshSlider(value);
        //Set prefered volume 
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        //Assign this to master volume mixer
        master.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(volumeSlider.value);
    }

    public void RefreshSlider(float value)
    {
        volumeSlider.value = value;
    }
}
