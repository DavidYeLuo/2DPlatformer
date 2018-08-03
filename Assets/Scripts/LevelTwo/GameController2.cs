using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    private int score;
    public Text scoreDisplay;

    [HideInInspector] public List<Ground> grounds = new List<Ground>(); // Could have used abstract/inheritance class called Ground so I don't have to use GameObject

    public GameObject heroCharacter;
    private SimplePlatformController2 player;

    private string color = "Blue"; // The Color of what is being solid


	private void Start()
    {
        player = heroCharacter.GetComponent<SimplePlatformController2>();

        scoreDisplay = scoreDisplay.GetComponent<Text>();
        score = 0;
        scoreDisplay.text = "Score: ";
        if (player == null)
            Debug.Log("Player Not found");
        PlatformUpdate();
    }

    private void FixedUpdate()
    {
        if (CheckColorMatch())
        {
            return;
        }
        else
        {
            SwitchColor();
            PlatformUpdate();
        }
    }

    public void AddScore(int num)
    {
        score += num;
    }
    
    public void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }

    public void AddGround(Ground ground)
    {
        grounds.Add(ground);
    }

    public void RemoveGround(GameObject ground)
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            if (grounds[i] == ground)
            {
                grounds.RemoveAt(i);
            }
        }
        Debug.Log("Item tried to remove not found");
    }

    private void SwitchColor()
    {
        if(color.Equals("Blue"))
        {
            color = "Red";
        }
        else if(color.Equals("Red"))
        {
            color = "Blue";
        }
        else
        {
            Debug.Log("In case for bugs");
        }
    }

    private bool CheckColorMatch()
    {
        return player.GetColor().Equals(color);
    }
    
    public void PlatformUpdate()
    {
        for(int i = 0; i < grounds.Count; i++)
        {
            if(grounds[i] == null)
            {
                Debug.Log("Found a null of at index" + i);
                grounds.RemoveAt(i);
                continue;
            }
            else if (color.Equals("Blue"))
            {
                if (grounds[i].name.Equals("Blue"))
                {
                    grounds[i].GetComponent<BlueGround>().bc2d.isTrigger = false;
                }
                else if(grounds[i].name.Equals("Red"))
                {
                    grounds[i].GetComponent<RedGround>().bc2d.isTrigger = true;
                }
            }
            else if(color.Equals("Red"))
            {
                if (grounds[i].name.Equals("Blue"))
                {
                    grounds[i].GetComponent<BlueGround>().bc2d.isTrigger = true;
                }
                else if (grounds[i].name.Equals("Red"))
                {
                    grounds[i].GetComponent<RedGround>().bc2d.isTrigger = false;
                }
            }
            else
            {
                Debug.Log("In case for bugs");
            }
        }
    }
}
