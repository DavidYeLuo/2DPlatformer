using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Switchable color on the player
// Left click to be red
// Right click to be blue
public class SimplePlatformController2 : SimplePlatformController 
{
    public GameObject colorCoating;
    private ColorCoating coatColor;
    private Renderer auraColor;
    private string color = "Blue";

    private void Start()
    {
        base.Start();
        coatColor = colorCoating.GetComponent<ColorCoating>();

    }

    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (coatColor.GetColor().Equals("Red"))
            {
                coatColor.BeBlue();
            }
            if (color.Equals("Red"))
            {
                SwitchColor();
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (coatColor.GetColor().Equals("Blue"))
            {
                coatColor.BeRed();
            }
            if (color.Equals("Blue"))
            {
                SwitchColor();
                // UpdateColor();
            }
        }
    }

    public void SwitchColor()
    {
        if(color.Equals("Red"))
        {
            color = "Blue";
        }
        else if (color.Equals("Blue"))
        {
            color = "Red";
        }
    }

    // Returns what color mode the player is on
    public string GetColor()
    {
        return color;
    }
}
