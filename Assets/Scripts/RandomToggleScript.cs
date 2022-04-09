using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************
// RandomToggleScript class, utility script/class for setting objects active / inactive.
//***********************************
public class RandomToggleScript : MonoBehaviour
{
    public GameObject toggableObject;

    public void ToggleObject()
    {
        if (toggableObject.active == true)
        {
            toggableObject.SetActive(false);
        }
        else
        {
            toggableObject.SetActive(true);
        }
    }
}
