using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns red and blue platforms randomly
public class SpawnManager2: SpawnManager
{
    private GameController2 gameController;
    public BlueGround bluePlatform;
    public RedGround redPlatform;
    
	void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject == null)
        {
            Debug.Log("GameController2 not found");
        }
        else
        {
            gameController = gameControllerObject.GetComponent<GameController2>();
        }

        // bluePlatform = platform;
        spawnPosition = transform.position;
        Spawn();
	}
    
    private void Spawn()
    {
        // Algorithm:
        // 1) Spawns a bluePlatform in the beginning
        // 2) Randomly spawn red or blue platform
        // 3) Spawn the next level platform
        if (gameController.grounds != null)
        {
            SpawnPlatform(bluePlatform); // First Platform that Player lands.

            for (int i = 0; i < maxPlatform; i++)
            {
                RandomizeSpawnPosition();
                if (Random.Range(0, 2) == 0) // Generates a number either 0 or 1
                {
                    SpawnPlatform(bluePlatform);
                }
                else
                {
                    SpawnPlatform(redPlatform);
                }
            }
            RandomizeSpawnPosition();
            SpawnPlatform(nextLevelPlatform);
            gameController.PlatformUpdate();
        }
    }

    // Spawns a desired platform at SpawnPosition with default rotation.
    private void SpawnPlatform(Ground platform)
    {
        gameController.AddGround(Instantiate(platform, spawnPosition, Quaternion.identity));
    }
}
