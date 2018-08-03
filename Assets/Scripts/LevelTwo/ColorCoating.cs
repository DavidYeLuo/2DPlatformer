using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCoating : MonoBehaviour
{
    public Material blue;
    public Material red;

    private Renderer myCoatColor;
    private string currentColor= "Blue";

    private void Start()
    {
        myCoatColor = GetComponent<Renderer>();
        myCoatColor.material = blue;
    }

    public string GetColor()
    {
        return currentColor;
    }

    public void BeBlue()
    {
        currentColor = "Blue";
        myCoatColor.material = blue;
    }

    public void BeRed()
    {
        currentColor = "Red";
        myCoatColor.material = red;
    }

}
