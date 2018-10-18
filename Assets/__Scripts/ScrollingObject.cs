﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = -1.5f;
    



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}