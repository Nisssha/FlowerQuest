using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Game  {

public static Game current;
public Flower daisy;
public Flower redRose;
public Flower dandelion;
//public string yas;

public Game () {
	daisy = new Flower();
	redRose = new Flower();
	dandelion = new Flower();
	//Debug.Log("Constructor is calledd?");
}

}
