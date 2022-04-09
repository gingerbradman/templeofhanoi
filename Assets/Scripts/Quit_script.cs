using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//***********************************
// Quit_script class for the quit game button GUI
//***********************************
public class Quit_script : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
}
