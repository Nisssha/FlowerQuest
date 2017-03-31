using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryState : MonoBehaviour {

    public DateTime playthroughTime; //time game was actually played
    public bool encounterOn;
  
    DateTime aiden1;
    public bool aiden1enc;
    public bool aiden1done;

    DateTime aiden2;
    public bool aiden2enc;
    public bool aiden2done;

    DateTime priest1;
    public bool priest1enc;
    public bool priest1done;

    public bool newGame = true;
    public bool dialogueOn;

    //sympathy points
    public int sympAiden;
    public int sympBenjamin;
    public int sympPriest;

    //suspicions
    public bool priestSus;
    public bool officerSus;

    //player knowledge
    public bool lucyFavFlower;

    public void Start()
    {
        if (newGame)
        {
            //setting sympathies levels
            sympAiden = 0;
            sympBenjamin = 0;
            sympPriest = 0;

            //aiden1 = startGame.AddMinutes(5); //5? or maybe after picking 1st flower?
            aiden1 = playthroughTime.AddMinutes(6);
            priest1 = playthroughTime.AddMinutes(9);
            aiden2 = playthroughTime.AddMinutes(12);
        }

        
        InvokeRepeating("AddTime", 1f, 1f);
    }

    public void Update()
    {
        if (playthroughTime.CompareTo(aiden1) == 1 && !aiden1enc && !aiden1done && !newGame)
        {
            encounterOn = true;
            aiden1enc = true;
            dialogueOn = true;
        }

        if (playthroughTime.CompareTo(priest1) == 1 && !priest1enc && !priest1done && !newGame)
        {
            encounterOn = true;
            priest1enc = true;
            dialogueOn = true;
        }

        if (playthroughTime.CompareTo(aiden2) == 1 && !aiden2enc && !aiden2done && !newGame)
        {
            encounterOn = true;
            aiden2enc = true;
            dialogueOn = true;
        }
    }

    public void SetSympathy(string name, int value)
    {
        if (name == "Aiden")
        {
            sympAiden += value;
        }
        else if (name == "Benjamin")
        {
            sympBenjamin += value;
        }
        else if (name == "Priest")
        {
            sympPriest += value;
        }
    }

    private void AddTime()
    {
        if (!encounterOn)
        {
            playthroughTime = playthroughTime.AddSeconds(1);
        }
    }
}
