﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{
    //position of the object
    Vector2  position;
    private Vector3 clickUser;
    
    private float movementSpeed;
    //default state is moving right
    //string state = "right";
    //camera view
    private float maxheight = 35f;
    private float minheight = -35f;
    //do not know why but these have to be private
    private float maxwidth = 51f;
    private float minwidth = -51f;
    //game points
    public int points = 0;
    //animation
    public Animator anim;

    public bool walkingRight;
    public bool movementReset;

    private int direction;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        Generate();
    }

    void Generate()
    {
        walkingRight ^= true;
        movementSpeed = movementSpeedRandomizer();
        position.y = positionYRandomizer();
    }
    
    // Update is called once per frame
    void Update()
    {
       transform.position = position;
       
       //direction = Random.Range(0, 1);
       
       if (position.x < (minwidth - 15) || position.x >= (maxwidth+ 10))
       {
            Generate();   
       }
      
       Move();
       
    }
    

    
    //Generating a random number that can be used for creating random speed
    static float movementSpeedRandomizer()
    {
        float min = 0.3f;
        float max = 1f;
        return Random.Range(min, max);
    }

    public float positionYRandomizer()
    {
        return Random.Range(minheight, maxheight);
    }

    void Move()
    {
        if (walkingRight)
        {
            anim.SetBool("WalkingRight", true);
            position.x += movementSpeed;
            //Debug.Log("moving right");
            //Debug.Log(position.x + " + " + movementSpeed + " = " + (position.x+movementSpeed));
        }
        else
        {
            anim.SetBool("WalkingRight", false);
            position.x -= movementSpeed;
            //Debug.Log("Moving left");
        }

    }

    void OnMouseDown()
    {
        points += 1;
    }
}
