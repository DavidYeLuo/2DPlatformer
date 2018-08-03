using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : Bullet {

    private static bool isCollisionOn = false;

	// Use this for initialization
	void Start () {
		base.name = "Blue";

        // Default start
        if (isCollisionOn)
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
        else
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            isCollisionOn = false;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
            isCollisionOn = true;
        }
    }

}
