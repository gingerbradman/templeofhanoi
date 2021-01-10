using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_script : MonoBehaviour
{
    public GameObject settings;

    public int maxDonuts;
    public bool randDonuts;

    public bool demoMode;

    public Stick StartStick;

    public Stick stick;
    public Stick stick2;
    public Stick stick3;
    public Donut donut1;
    public Donut donut2;
    public Donut donut3;
    public Donut donut4;
    public Donut donut5;
    public Donut donut6;
    public Donut donut7;

    private Stick stickPick;
    public Stick GetStickPick() { return stickPick; }
    public void SetStickPick(Stick x) { stickPick = x; }

    private Stick stickPlace;
    public Stick GetStickPlace() { return stickPlace; }
    public void SetStickPlace (Stick x) { stickPlace = x; }

    private Donut donutPick;
    public Donut GetDonutPick() { return donutPick; }
    public void SetDonutPick(Donut x) { donutPick = x; }

    public SpriteRenderer selectedDonut;

    public TextMeshProUGUI winText;

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
        if (demoMode)
        {
            maxDonuts = 3;
        }
        else
        {
            settings = GameObject.Find("Settings");
            randDonuts = settings.GetComponent<Settings>().getRandomDonuts();
            maxDonuts = settings.GetComponent<Settings>().getHowManyDonuts();

            if (randDonuts)
            {
                int randomDonutAmount = Random.Range(3, 7);
                maxDonuts = randomDonutAmount;
            }
        }

        Invoke("Setup", .1f);
    }

    void Setup()
    {
        switch (maxDonuts) { 
        case 1:
                donut1 = Instantiate(donut1);

                stick.AttemptToPlace(donut1);
                break; 
        case 2:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);

                stick.AttemptToPlace(donut2);
                stick.AttemptToPlace(donut1);
                break; 
        case 3:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);

                stick.AttemptToPlace(donut3);
                stick.AttemptToPlace(donut2);
                stick.AttemptToPlace(donut1);
                break; 
        case 4:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);

                stick.AttemptToPlace(donut4);
                stick.AttemptToPlace(donut3);
                stick.AttemptToPlace(donut2);
                stick.AttemptToPlace(donut1);
                break; 
        case 5:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);
                donut5 = Instantiate(donut5);

                stick.AttemptToPlace(donut5);
                stick.AttemptToPlace(donut4);
                stick.AttemptToPlace(donut3);
                stick.AttemptToPlace(donut2);
                stick.AttemptToPlace(donut1);
                break; 
        case 6:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);
                donut5 = Instantiate(donut5);
                donut6 = Instantiate(donut6);

                stick.AttemptToPlace(donut6);
                stick.AttemptToPlace(donut5);
                stick.AttemptToPlace(donut4);
                stick.AttemptToPlace(donut3);
                stick.AttemptToPlace(donut2);
                stick.AttemptToPlace(donut1);
                break; 
        case 7:
                donut1 = Instantiate(donut1);
                donut2 = Instantiate(donut2);
                donut3 = Instantiate(donut3);
                donut4 = Instantiate(donut4);
                donut5 = Instantiate(donut5);
                donut6 = Instantiate(donut6);
                donut7 = Instantiate(donut7);

                stick.AttemptToPlace(donut7);
                stick.AttemptToPlace(donut6);
                stick.AttemptToPlace(donut5);
                stick.AttemptToPlace(donut4);
                stick.AttemptToPlace(donut3);
                stick.AttemptToPlace(donut2);
                stick.AttemptToPlace(donut1);
                break;
        }
        SetState(State.Pick);
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
        SetStickPlace(null);
        SetDonutPick(null);
    }

    public void RemoveTopDonut()
    {
        if (GetStickPick() != null)
        {
            GetStickPick().donutList.Remove(GetStickPick().GetTop());
        }

    }

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

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    private void Update()
    {
        
    }


}
