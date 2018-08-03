using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Switchable color on the player
// Left click to be red
// Right click to be blue
public class SimplePlatformController3 : SimplePlatformController 
{
    public Text healthDisplay;
    public int health = 5;
    private bool hit = false;

    public GameObject colorCoating;
    private ColorCoating coatColor;
    private Renderer auraColor;
    private string color;

	private BulletSpawner spawner;
	public GameObject spawnerRef;

    private void Start()
    {
        base.Start();
        color = "Blue";
        coatColor = colorCoating.GetComponent<ColorCoating>();
		spawner = spawnerRef.GetComponent<BulletSpawner> ();
        healthDisplay.GetComponent<Text>().text = "Health: " + health;
        UpdateHealth();
    }

    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))
            || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Bullet"));

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        // switch to blue
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
        // Switch to red
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
        if(health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            if(!hit)
            {
                health--;
                UpdateHealth();
            }
            hit = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hit = false;
        }
    }
    private void UpdateHealth()
    {
        healthDisplay.GetComponent<Text>().text = "Health: " + health;
    }
}
