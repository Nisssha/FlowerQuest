using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpHandle : MonoBehaviour {

    int over;
    int timeToSubtract;

	public void WinFlowerQuest (int overGoal)
    {
        over = overGoal;
        Debug.Log("WinFlowerQuest called. Over: " + over);

        if(over <= 1000)
        {
            timeToSubtract = 300;
        }else if(over > 1000 && over <= 3000)
        {
            timeToSubtract = 600;
        }else if(over > 3000)
        {
            timeToSubtract = 1200;
        }

        //get all the flower growing components, add appopriate time to them, that's it?
        FlowerGrowing[] flowersGrowing = GameObject.FindObjectsOfType<FlowerGrowing>();

        foreach (FlowerGrowing flower in flowersGrowing)
        {
            flower.SpeedUpGrowth(timeToSubtract);
        }
    }
}
