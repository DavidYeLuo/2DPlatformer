using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Restarts level when player touches
// but destroys anything in contact.
public class DeathTrigger2 : MonoBehaviour
{
    private GameController2 gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject == null)
        {
            Debug.Log("GameController2 not found");
        }
        else
        {
            gameController = gameControllerObject.GetComponent<GameController2>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            gameController.RemoveGround(other.gameObject);
            // Destroy(other.gameObject);
        }
    }

}

