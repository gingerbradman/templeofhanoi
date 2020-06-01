using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_script : MonoBehaviour
{

    public Stick stick;
    public Donut donut1;
    public Donut donut2;
    public Donut donut3;

    // Start is called before the first frame update
    void Start()
    {
//        Instantiate(stick);
//        Instantiate(donut1);
//        Instantiate(donut2);
//        Instantiate(donut3);   
    }

    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            Debug.Log(stick.stickStack.Count + " Stack Count");
        }

        if (Input.GetKeyDown("z"))
        {
            stick.attemptToPlace(donut1);
        }

        if (Input.GetKeyDown("x"))
        {
            stick.attemptToPlace(donut2);
        }

        if (Input.GetKeyDown("c"))
        {
            stick.attemptToPlace(donut3);
        }
    }


}
