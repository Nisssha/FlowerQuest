using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stuff : MonoBehaviour {

//private Text text;
	// Use this for initialization
	void Start () {
	//text = GameObject.FindObjectOfType<Text>();
	//text.text = Game.yas;
	SaveLoad.Load();
	Game game = new Game();	
	}

	void Update(){

	}

}
