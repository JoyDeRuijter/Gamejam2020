﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Sharing;

public class MeetPeopleQuest : Quest
{
    void Awake()                //As soon as its added, everything must be immediately available
    {
        questName = "Meet People";
        description = "Go introduce yourself!";
        //skillRewards = FindObjectOfType<GameManager>().scoreFriends;
        goal = new TalkGoal(2, this);
        
        //EventController.NpcInteracted(0);
    }

    public override void Complete()
    {
        GrantReward("friends", 15, null, 0);
        GrantReward("party", 10, null, 0);
        base.Complete();
    }
}
