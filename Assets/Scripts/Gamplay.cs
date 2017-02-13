using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamplay : MonoBehaviour {

	static GameObject[] flowers;

	public static void UpdateFlowers (){
		flowers = GameObject.FindGameObjectsWithTag("Flower");
	}


}
