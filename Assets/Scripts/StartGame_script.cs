using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//***********************************
// StartGame_script class; when the game begins, we gather the details we need from settings.
//***********************************
public class StartGame_script : MonoBehaviour
{
    public Slider sliderValue;
    public Toggle random;
    public GameObject settings;

    public void PlayGame()
    {
        settings = GameObject.Find("Settings");
        settings.GetComponent<Settings>().setHowManyDonuts((int) sliderValue.value);
        settings.GetComponent<Settings>().setRandomDonuts(random.isOn);
        SceneManager.LoadScene("GameScene");
    }
}
