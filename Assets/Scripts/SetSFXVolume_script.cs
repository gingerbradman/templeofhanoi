using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//***********************************
// SetSFXVolume_script class used to determine SFX volume based on sliders in settings.
//***********************************
public class SetSFXVolume_script : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) *20);
    }
}
