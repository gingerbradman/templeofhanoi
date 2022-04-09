using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//***********************************
// PlayAgain_script class for the play again GUI Button
//***********************************
public class PlayAgain_script : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
