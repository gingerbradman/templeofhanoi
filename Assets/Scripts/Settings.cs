using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//***********************************
// Settings Class which is manipulated on the scene before the game starts, determining the difficulty by setting an amount of donuts to play with.
//***********************************
public class Settings : MonoBehaviour
{
    // Settings Instance used to complete the singleton pattern.
    private static Settings _instance;
    // Public-like usage to check the instance.
    public static Settings Instance {get { return _instance; } }
    // Integer for how many donuts the player has selected.
    private int howManyDonuts;
    // Boolean incase the player selects they would like to play with random donuts, clamped between 3 to 7.
    private bool randomDonuts = false;
    // Getter for how many donuts were chosen.
    public int getHowManyDonuts() { return howManyDonuts; }
    // Setter for how many donuts were chosen.
    public void setHowManyDonuts(int x) { howManyDonuts = x; }
    // Getter for random donut bool.
    public bool getRandomDonuts() { return randomDonuts; }
    // Setter for random donut bool.
    public void setRandomDonuts(bool x) { randomDonuts = x; }

    // Settings is a singleton that isn't destroyed.
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }


        DontDestroyOnLoad(gameObject);
    }
}
