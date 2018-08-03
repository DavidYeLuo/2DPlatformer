using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public string name;
    private GameController2 gameController;

    private void Start()
    {
        // Find GameController.
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject == null)
        {
            Debug.Log("GameController not found");
        }
        else
        {
            gameController = gameControllerObject.GetComponent<GameController2>();
        }
    }

}
