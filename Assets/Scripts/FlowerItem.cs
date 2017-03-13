using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlowerItem{

public string name;
public DateTime plantTime;
public DateTime growTime;
public Vector3 flowerPosition;
public Sprite flowerSprite;
    //public Planting Planting;

    public FlowerItem(string flowerName, DateTime flowerPlantTime, DateTime flowerGrowTime, Vector3 flowerPositionInstance, Sprite sprite)
    {
        name = flowerName;
        plantTime = flowerPlantTime;
        growTime = flowerGrowTime;
        flowerPosition = flowerPositionInstance;
      //  Debug.Log("flower item created");
        flowerSprite = sprite;
    }

    public FlowerItem ()
    {

    }

}
