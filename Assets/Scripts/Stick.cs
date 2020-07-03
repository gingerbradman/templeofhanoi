using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public GameManager_script manager;

    public Slots slot;

    private float slotHeight = -0.5f;
    public float GetSlotHeight() { return slotHeight; }
    public void SetSlotHeigh(float x) { slotHeight = x; }

    public List<Donut> donutList;
    public List<Slots> slotsList;

    public SpriteRenderer selectedDonut;

    private void Start()
    {
        this.donutList = new List<Donut>();
        this.slotsList = new List<Slots>();

        for (int i = 0; i < manager.maxDonuts; i++)
        {
            Transform child = this.transform;
            Slots slotChild = Instantiate(slot);
            slotChild.name = "Slot " + i;
            slotChild.slotName = "Slot " + i;
            slotChild.transform.parent = child;
            slotsList.Add(slotChild);
            if (i == 0)
            {
                slotChild.transform.position = slotChild.transform.position + new Vector3(0, GetSlotHeight(), 0);
            }
            else
            {
                slotChild.transform.position = slotChild.transform.position + new Vector3(0, GetSlotHeight() + 0.08f, 0);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < slotsList.Count; i++)
        {
            if (slotsList[i].transform.childCount >= 1)
            {
                slotsList[i].enabled = false;
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedDonut = this.transform.Find(GetTopString()).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
            manager.SetPick(this, selectedDonut);
        }
    }

public void AttemptToPlace(Donut x)
    {
        if (this.donutList.Count == 0)
        {
            PutOnStick(x);
            Debug.Log("attemptToPlace If stick in empty get placed");
        }
        else
        {
            CheckIfSmaller(x);
        }
    }

    public void CheckIfSmaller(Donut x)
    {
        if (x.GetSize() < GetTop().GetSize())
        {
            PutOnStick(x);
        }
        else
        {

        }
    }

    public string GetTopString()
    {
        int x = donutList.Count;
        string slot = "Slot ";
        return (slot + (x - 1));
    }

    public Donut GetTop()
    {
        int x = donutList.Count;
        return donutList[(x - 1)];
    }

    public void PutOnStick(Donut x)
    {
        this.donutList.Add(x);
        GameObject child = this.transform.Find(GetTopString()).gameObject;
        x.transform.parent = child.transform;
        x.transform.position = child.transform.position;
        Debug.Log("Donut is put in list");
    }
}
