﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendsGoal : MonoBehaviour
{
    public Text goalText;
    public int goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = 20;
        goalText.text = "Goal: " + goal;
    }
}