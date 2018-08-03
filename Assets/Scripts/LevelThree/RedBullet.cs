using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : Bullet
{

    private static bool isCollsionOn = true;

	void Start ()
    {
		base.name = "Red";
        // Default start
        if(isCollsionOn)
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
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
            isCollsionOn = true;
        }
        if(Input.GetButtonDown("Fire2"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            isCollsionOn = false;
        }
    }

}
