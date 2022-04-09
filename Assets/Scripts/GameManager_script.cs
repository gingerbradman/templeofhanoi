using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//***********************************
// GameManager_script Class assigned to the Game Manager Singleton Object
//      Handles the initial set-up of the game as well as win conditions.
//***********************************
public class GameManager_script : MonoBehaviour
{

    // Settings gameobject that is manipulated on the page before the game. Used to know how hard to make the game.    
    public GameObject settings;

    // Integer for the maximum amount of donuts in the game. Clamped between 3 and 7.
    public int maxDonuts;
    // Integer for a random amount of donuts. Used if a random difficulty is selected.
    public bool randDonuts;
    // Boolean for if currently in demo mode. Used purely for debugging and development from the main game scene.
    public bool demoMode;
    // Game Object keeping track of the center stick. The tower must be reconstructed on any tower but the center one.
    public Stick StartStick;
    // Game Object for the center stick. While similar to the above variable, this one is used exclusively for placing the donuts.
    public Stick stick;
    // Prefab-like Object for Donut 1
    public Donut donut1;
    // Prefab-like Object for Donut 2
    public Donut donut2;
    // Prefab-like Object for Donut 3
    public Donut donut3;
    // Prefab-like Object for Donut 4
    public Donut donut4;
    // Prefab-like Object for Donut 5
    public Donut donut5;
    // Prefab-like Object for Donut 6
    public Donut donut6;
    // Prefab-like Object for Donut 7
    public Donut donut7;
    // Stick the player takes the donut from. Stored incase the player places the donut back on the stick it was originally on.
    private Stick stickPick;
    // Getter Stick Pick
    public Stick GetStickPick() { return stickPick; }
    // Setter Stick Pick
    public void SetStickPick(Stick x) { stickPick = x; }
    // Stick the player attempts to place the donut on. Stored for comparison between original and new stick placements. 
    private Stick stickPlace;
    // Getter Stick Place
    public Stick GetStickPlace() { return stickPlace; }
    // Setter Stick Place
    public void SetStickPlace (Stick x) { stickPlace = x; }
    // Donut the player has picked up.
    private Donut donutPick;
    // Getter Donut Pick
    public Donut GetDonutPick() { return donutPick; }
    // Setter Donut Pick
    public void SetDonutPick(Donut x) { donutPick = x; }
    // Sprite Renderer for the selectedDonuts to make them opaque and signify they've been selected.
    public SpriteRenderer selectedDonut;

    // Enum for Game Manager State Machine
    public enum State
    {
        Setup,      // Set as default, player should not be able to interact during this phase.
        Pick,       // Set once setup is complete or a placement has been made, player should now be able to pick.
        Place,      // Set once a pick has been selected, player should now be able to place a donut.
        GameOver    // Set once game has been completed and the tower reconstructed.
    };

    // Game Manager Compact State Machine Variable
    private State managerState;
    // Getter for State
    public State GetState() { return managerState; }
    // Setter for State
    public void SetState(State x){ managerState = x; }

    // Start is called before the first frame update
    void Start()
    {
        // If in demo, default to spawning three donuts.
        if (demoMode)
        {
            maxDonuts = 3;
        }
        // Else use the settings object to determine difficulty.
        else
        {
            settings = GameObject.Find("Settings");
            randDonuts = settings.GetComponent<Settings>().getRandomDonuts();
            maxDonuts = settings.GetComponent<Settings>().getHowManyDonuts();

            // If random is selected in settings, determine a random amount between 3 and 7
            if (randDonuts)
            {
                int randomDonutAmount = Random.Range(3, 7);
                maxDonuts = randomDonutAmount;
            }
        }

        // Invoke Setup function
        Invoke("Setup", .1f);
    }

    // Function which populates the donuts onot the center stick.
    void Setup()
    {
        // How many donuts do we have? For that many, instantiate a donut and place it on the center stick.
        switch (maxDonuts) { 
        case 1: // Realistically this case is never called. Here for debugging purposes.
                donut1 = Instantiate(donut1);

                stick.PutOnStick(donut1);
                break; 
        case 2: // Realistically this case is never called. Here for debugging purposes.
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);

                stick.PutOnStick(donut2);
                stick.PutOnStick(donut1);
                break; 
        case 3: // Standard Minimum Case
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);

                stick.PutOnStick(donut3);
                stick.PutOnStick(donut2);
                stick.PutOnStick(donut1);
                break; 
        case 4:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);

                stick.PutOnStick(donut4);
                stick.PutOnStick(donut3);
                stick.PutOnStick(donut2);
                stick.PutOnStick(donut1);
                break; 
        case 5:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);
                donut5 = Instantiate(donut5);

                stick.PutOnStick(donut5);
                stick.PutOnStick(donut4);
                stick.PutOnStick(donut3);
                stick.PutOnStick(donut2);
                stick.PutOnStick(donut1);
                break; 
        case 6:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);
                donut5 = Instantiate(donut5);
                donut6 = Instantiate(donut6);

                stick.PutOnStick(donut6);
                stick.PutOnStick(donut5);
                stick.PutOnStick(donut4);
                stick.PutOnStick(donut3);
                stick.PutOnStick(donut2);
                stick.PutOnStick(donut1);
                break; 
        case 7: // Standard Maxmimum Case
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);
                donut5 = Instantiate(donut5);
                donut6 = Instantiate(donut6);
                donut7 = Instantiate(donut7);

                stick.PutOnStick(donut7);
                stick.PutOnStick(donut6);
                stick.PutOnStick(donut5);
                stick.PutOnStick(donut4);
                stick.PutOnStick(donut3);
                stick.PutOnStick(donut2);
                stick.PutOnStick(donut1);
                break;
        }

        // Set Game Manager state to allow the player to interact.
        SetState(State.Pick);
    }


    // Function for when a player chooses a stick. Take the top donut from that stick and move the game manager to the place state.
    public void SetPick(Stick x, SpriteRenderer sprite)
    {   
        SetStickPick(x);
        SetDonutPick(x.transform.Find(x.GetTopString()).gameObject.transform.GetChild(0).GetComponent<Donut>());
        sprite.color = new Color(1f, 1f, 1f, .5f);
        SetState(State.Place);
    }


    // Function to clear the donut selection and revert the game manager to the pick state.
    public void CancelPick()
    {
        ClearSets();
        SetState(State.Pick);
    }

    // Function to clear all set pick and places become cleared.
    public void ClearSets()
    {
        SetStickPick(null);
        SetStickPlace(null);
        SetDonutPick(null);
    }

    // Function to remove the top donut from the selected picked stick.
    public void RemoveTopDonut()
    {
        if (GetStickPick() != null)
        {
            GetStickPick().donutList.Remove(GetStickPick().GetTop());
        }

    }

    // Function which checks to see if the player won.
    // If we place a donut on a stick that isn't the center one, check to see if the number of donuts on it, matches the maxDonut variable.
    //  If so, win the game; if not, keep going.
    public void CheckForWin()
    {
        Debug.Log("In CheckForWin");
        if (GetStickPlace() != null)
        {
            if (GetStickPlace() == StartStick)
            {
                //Do Nothing
            }
            else if (GetStickPlace().donutList.Count == maxDonuts)
            {
                SetState(State.GameOver);
                WinGame();
            }
        }
    }

    // Function to move to the victory scene.
    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }
}
