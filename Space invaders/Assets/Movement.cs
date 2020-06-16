﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D ship;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        ship = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }
}