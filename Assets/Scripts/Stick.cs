using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Stack<Donut> stickStack;

    private void Start()
    {
        this.stickStack = new Stack<Donut>();
    }

    public void attemptToPlace(Donut x)
    {
        if (this.stickStack.Count == 0)
        {
            putOnStick(x);
            Debug.Log("attempToPlace If stack in empty get placed");
        }
        checkIfSmaller(x);
    }

    public void checkIfSmaller(Donut x)
    {
        if (x.getSize() < this.stickStack.Peek().getSize())
        {
            Debug.Log("Donut placed was smaller than donut ontop of stick");
            putOnStick(x);
        }
        else
        {
            Debug.Log("Donut placed was bigger than donut ontop of stick");
        }
    }


    public void putOnStick(Donut x)
    {
        this.stickStack.Push(x);
        Debug.Log("Donut is pushed on stack");
    }
}
