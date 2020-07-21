using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_script : MonoBehaviour
{

    public int maxDonuts = 2;

    public Stick stick;
    public Stick stick2;
    public Stick stick3;
    public Donut donut1;
    public Donut donut2;
    public Donut donut3;

    private Stick stickPick;
    public Stick GetStickPick() { return stickPick; }
    public void SetStickPick(Stick x) { stickPick = x; }

    private Donut donutPick;
    public Donut GetDonutPick() { return donutPick; }
    public void SetDonutPick(Donut x) { donutPick = x; }

    public SpriteRenderer selectedDonut;

    public enum State
    {
        Setup,
        Pick,
        Place,
        GameOver
    };

    private State managerState;
    public State GetState() { return managerState; }
    public void SetState(State x){ managerState = x; }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Setup", .1f);
    }

    void Setup()
    {
        donut1 = Instantiate(donut1);
        donut2 = Instantiate(donut2);

        stick.AttemptToPlace(donut2);
        stick.AttemptToPlace(donut1);
        SetState(State.Pick);
        Debug.Log(GetState());
    }

    public void SetPick(Stick x, SpriteRenderer sprite)
    {   
        SetStickPick(x);
        SetDonutPick(x.transform.Find(x.GetTopString()).gameObject.transform.GetChild(0).GetComponent<Donut>());
        sprite.color = new Color(1f, 1f, 1f, .5f);
        SetState(State.Place);
    }

    public void CancelPick()
    {
        ClearSets();
        SetState(State.Pick);
    }

    public void ClearSets()
    {
        SetStickPick(null);
        SetDonutPick(null);
    }

    public void RemoveTopDonut()
    {
        GetStickPick().donutList.Remove(GetStickPick().GetTop());
    }


    private void Update()
    {

    }


}
