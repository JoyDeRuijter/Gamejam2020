﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro.EditorUtilities;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Entity entity;
    Character character;
    Tile tile;
    NPC npc;

    public void Start()
    {
        Generate();
    }

    public void Generate()
    {
        tile = GetComponent<Tile>();
        character = this.GetComponent<Character>();
        entity = GetComponent<Entity>();
        
        npc = FindObjectOfType<NPC>();
    }

    void Update()
    {
        HandleInput();
        tile.IdTile(entity.currentPosition.X, entity.currentPosition.Y, 1);                //can this be moved elsewhere? Maybe after each move?
    }

    void HandleInput()
    {
        if (character.isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                character.isMoving = true;
                character.Move(0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                character.isMoving = true;
                character.Move(1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                character.isMoving = true;
                character.Move(2);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                character.isMoving = true;
                character.Move(3);
            }
        }


        //TO DO:    Add interaction for all interactable objects (like trash bins, etc.), make a new script for this.       
        //          Expand on it, so each object may have different results when interacted with
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Interacting..");
            //Nog een beetje vies, en werkt momenteel niet voor iedere NPC apart
            switch (character.Direction)
            {
                case 0:
                    if (entity.currentPosition.X == npc.entity.currentPosition.X && entity.currentPosition.Y - 1 == npc.entity.currentPosition.Y)
                        npc.Interacted();
                    break;
                case 1:
                    if (entity.currentPosition.X == npc.entity.currentPosition.X && entity.currentPosition.Y + 1 == npc.entity.currentPosition.Y)
                        npc.Interacted();
                    break;
                case 2:
                    if (entity.currentPosition.X - 1 == npc.entity.currentPosition.X && entity.currentPosition.Y == npc.entity.currentPosition.Y)
                        npc.Interacted();
                    break;
                case 3:
                    if (entity.currentPosition.X + 1 == npc.entity.currentPosition.X && entity.currentPosition.Y == npc.entity.currentPosition.Y)
                        npc.Interacted();
                    break;
                default:
                    break;
            }
        }
    }
}
