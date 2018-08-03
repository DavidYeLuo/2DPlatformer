using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGround : Ground
{
    [HideInInspector] public BoxCollider2D bc2d;

	private void Start ()
    {
        bc2d = GetComponent<BoxCollider2D>();
        base.name = "Blue";
	}

}
