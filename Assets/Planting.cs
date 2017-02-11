using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planting : MonoBehaviour {

	public GameObject narcis;

void Update(){
	//	if (Input.GetMouseButtonDown(1)){
	//
	//		Click();
	//	}
}

	public void Click(){

			Debug.Log ("Pot clicked");
			Vector3 flowerPosition = new Vector3(this.transform.position.x+6, this.transform.position.y +35, this.transform.position.z);

			GameObject flower = Instantiate(narcis, flowerPosition, Quaternion.identity);
			flower.transform.SetParent(GameObject.FindObjectOfType<Button>().transform, false);

		
	}
}
