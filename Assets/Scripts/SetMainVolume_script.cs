using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//***********************************
// SetVolume_script class used to determine volume based on sliders in settings.
//***********************************
public class SetVolume_script : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) *20);
    }
}
