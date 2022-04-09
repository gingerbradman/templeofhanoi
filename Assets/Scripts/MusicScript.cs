using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************
// MusicScript class for handling the audio manager
//***********************************
public class MusicScript : MonoBehaviour
{
    public static MusicScript instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

}
