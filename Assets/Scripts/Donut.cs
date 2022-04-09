using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************
// Donut Class assigned to each donut
//***********************************
public class Donut : MonoBehaviour
{
    // Integer value used to keep track of donut size and is used when comparing donuts
    public int size;

    // Stick that the donut is currently on
    public Stick stick;

    // Getter value for the size of the donut
    public int GetSize() { return size; }

    // When we mouse over donut, run the select-top donut on the current clicked-on stick function.
    private void OnMouseOver()
    {
        stick.selectDonut();
    }
}
