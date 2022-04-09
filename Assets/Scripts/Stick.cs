using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

//***********************************
// Stick Class, there's three sticks in the game and each are comprised of slots.
//      This Class contains most of the logic that dictates whether a donut can or cannot be placed on a stick by pulling variables from the game manager.
//***********************************
public class Stick : MonoBehaviour
{
    // Game Manager Variable; used to get max number of donuts or find out what selected sticks or donuts the player has chosen.
    public GameManager_script manager;
    // Slot Variable, each slot is used as a space for a donut to be placed.
    public Slots slot;
    // Sound effect played when a donut is placed.
    public AudioSource correctSound;
    // Sound effect played when a donut cannot be placed.
    public AudioSource wrongSound;
    // Iterable Variable for slots.
    public float slot_x;
    // Distance between slots.
    private float slotHeight = -0.5f;
    // Getter for distance between slots.
    public float GetSlotHeight() { return slotHeight; }
    // Setter for distance between slots.
    public void SetSlotHeight(float x) { slotHeight = x; }
    // Donut list which contains all the donuts placed on the current stick.
    public List<Donut> donutList;
    // Slots list which contains all the slots the stick has.
    public List<Slots> slotsList;

    private void Start()
    {
        // Instantiate the lists
        this.donutList = new List<Donut>();
        this.slotsList = new List<Slots>();

        // For the max amount of donuts, make and place a slot.
        for (int i = 0; i < manager.maxDonuts; i++)
        {
            Transform child = this.transform;
            Slots slotChild = Instantiate(slot);
            slotChild.name = "Slot " + i;
            slotChild.slotName = "Slot " + i;
            slotChild.transform.parent = child;
            slotsList.Add(slotChild);

            //The 0.08f "magic number" that is used is the distance between the donuts in height. Alternatively we could make the slots using canvas,
            //  however I opted for this path to test building games with generated parameters.
            if (i == 0)
            {
                slotChild.transform.position = slotChild.transform.position + new Vector3(slot_x, GetSlotHeight(), 0);
            }
            else
            {
                slotChild.transform.position = slotChild.transform.position + new Vector3(slot_x, GetSlotHeight() + 0.08f, 0);
                SetSlotHeight(GetSlotHeight() + 0.08f);
            }
        }
    }


    private void Update()
    {
        // Every frame we disable the slots that have donuts, this is done so we can freely select a stick without the donut game object blocking OnMouseOver.
        for (int i = 0; i < slotsList.Count; i++)
        {
            if (slotsList[i].transform.childCount >= 1)
            {
                slotsList[i].enabled = false;
            }
        }
    }

    // Function in which we select the top donut when we pick a stick.
    private void OnMouseOver()
    {
        selectDonut();
    }

    // Function where we grab the donut at the top of the stick and select it.
    public void selectDonut()
    {
        // When we press down
        if (Input.GetMouseButtonDown(0))
        {
            // If we are in the pick state and this stick has a donut.
            if (manager.GetState() == GameManager_script.State.Pick && this.donutList.Count != 0)
            {
                // Select this stick's top donut.
                manager.selectedDonut = this.transform.Find(GetTopString()).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
                manager.selectedDonut.color = new Color(1f, 1f, 1f, .5f);
                manager.SetPick(this, manager.selectedDonut);
            }
            // If we are in the place state and this stick is the stick with the selected donut
            else if (manager.GetState() == GameManager_script.State.Place && this == manager.GetStickPick())
            {
                // Cancel the pick.
                manager.selectedDonut.color = new Color(1f, 1f, 1f, 1f);
                manager.CancelPick();
            }
            // If we are in the place state and this stick is not the stick with the selected donut
            else if (manager.GetState() == GameManager_script.State.Place && this != manager.GetStickPick())
            {
                // Attempt to place
                manager.selectedDonut.color = new Color(1f, 1f, 1f, 1f);
                this.AttemptToPlace(manager.GetDonutPick());
                manager.CancelPick();
            }
            // Else cancel the pick
            else
            {
                if (manager.selectedDonut != null)
                {
                    manager.selectedDonut.color = new Color(1f, 1f, 1f, 1f);
                }
                manager.CancelPick();
            }
        }
    }

    // Function to attempt donut placement.
    public void AttemptToPlace(Donut x)
    {
        // If this stick has no donuts, place it.
        if (this.donutList.Count == 0)
        {  
            // Place donut on stick
            PutOnStick(x);
            correctSound.Play();
        }
        // If we have donuts
        else
        {
            // Check if the stick the player is trying to place is smaller than the top donut we have.
            CheckIfSmaller(x);
        }
    }

    // Function to check if the donut is smaller than the top donut on the current stick.
    public void CheckIfSmaller(Donut x)
    {
        // Compare Donut Sizes
        // If smaller, put on stick
        if (x.GetSize() < GetTop().GetSize())
        {
            PutOnStick(x);
            correctSound.Play();
        }
        // If not smaller, don't place on stick
        else
        {
            wrongSound.Play();
        }
    }

    // Function to return the top level slot string
    public string GetTopString()
    {
        int x = donutList.Count;
        string slot = "Slot ";
        return (slot + (x - 1));
    }

    // Function to return the top donut on the stick
    public Donut GetTop()
    {
        int x = donutList.Count;
        return donutList[(x - 1)];
    }
    
    // Function to place the parameter donut on the stick.
    public void PutOnStick(Donut x)
    {
        // Set this stick as the placed one
        manager.SetStickPlace(this);

        // Remove the top donut 
        manager.RemoveTopDonut();

        // Add the parameter donut to the list and place it on screen
        this.donutList.Add(x);
        x.stick = this;
        GameObject child = this.transform.Find(GetTopString()).gameObject;
        x.transform.parent = child.transform;
        x.transform.position = child.transform.position;

        // Check if the player won
        manager.CheckForWin();

    }
}
