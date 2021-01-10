using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public int size;
    public Stick stick;

    public int GetSize() { return size; }
    public void SetSize(int x) { this.size = x; }

    private void OnMouseOver()
    {
        stick.selectDonut();
    }
}
