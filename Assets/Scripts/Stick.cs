using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public GameManager_script manager;

    public Slots slot;

    public float slot_x;
    private float slotHeight = -0.5f;
    public float GetSlotHeight() { return slotHeight; }
    public void SetSlotHeight(float x) { slotHeight = x; }

    public List<Donut> donutList;
    public List<Slots> slotsList;

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
        selectDonut();
    }

    public void selectDonut()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (manager.GetState() == GameManager_script.State.Pick && this.donutList.Count != 0)
            {
                manager.selectedDonut = this.transform.Find(GetTopString()).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
                manager.selectedDonut.color = new Color(1f, 1f, 1f, .5f);
                manager.SetPick(this, manager.selectedDonut);
            }
            else if (manager.GetState() == GameManager_script.State.Place && this == manager.GetStickPick())
            {
                manager.selectedDonut.color = new Color(1f, 1f, 1f, 1f);
                manager.CancelPick();
            }
            else if (manager.GetState() == GameManager_script.State.Place && this != manager.GetStickPick())
            {
                manager.selectedDonut.color = new Color(1f, 1f, 1f, 1f);
                this.AttemptToPlace(manager.GetDonutPick());
                manager.CancelPick();
            }
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

public void AttemptToPlace(Donut x)
    {
        if (this.donutList.Count == 0)
        {
            PutOnStick(x);
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
        manager.SetStickPlace(this);
        manager.RemoveTopDonut();
        this.donutList.Add(x);
        x.stick = this;
        GameObject child = this.transform.Find(GetTopString()).gameObject;
        x.transform.parent = child.transform;
        x.transform.position = child.transform.position;
        manager.CheckForWin();

    }
}
