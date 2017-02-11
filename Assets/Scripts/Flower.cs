using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Flower{

public string name;
public DateTime plantTime;
public DateTime growTime;

public Flower () {

plantTime = DateTime.Now;
Debug.Log("planted at: " +plantTime);
float randTier = UnityEngine.Random.value;
float randFlower = UnityEngine.Random.value;
//common
if (randTier <= 0.5f){ //should be 0.5
	if (randFlower < 0.33f){
		this.name = "Daisy";
		growTime = plantTime.AddHours(2);
	}else if (0.33f <= randFlower && randFlower < 0.66f){
		this.name = "Red rose";
		growTime = plantTime.AddHours(3);
	}else if(0.66f <= randFlower && randFlower <= 1f){
		this.name = "Dandelion";	
		growTime = plantTime.AddHours(1);
	}

}
//normal
if (randTier >= 0.5f && randTier < 0.9f){
	if (randFlower < 0.33f){
		this.name = "Pink rose";
		growTime = plantTime.AddHours(5);
	}else if (0.33f <= randFlower && randFlower < 0.66f){
		this.name = "Tulip";
		growTime = plantTime.AddHours(7);
	}else if(0.66f <= randFlower && randFlower <= 1f){
		this.name = "Narcissus";	
		growTime = plantTime.AddHours(7);
	}
}
//rare
if (randTier >= 0.9f && randTier <= 1f){
	if (randFlower < 1f){
		this.name = "Black rose";
		growTime = plantTime.AddHours(12);
	}
}
//very rare TODO later, change value of rare tier
	//this.name = "";

	Debug.Log(this.name);
	Debug.Log("Will grow at: " +growTime);
}
}
