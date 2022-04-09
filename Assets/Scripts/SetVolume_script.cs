using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//***********************************
// SetMainVolume_script class, implements a log converter to make the volume affected by the slider more realistic in sound.
//***********************************
public class SetMainVolume_script : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) *20);
    }
}
