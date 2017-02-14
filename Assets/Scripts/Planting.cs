using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Planting : MonoBehaviour {

	public GameObject daisy;
	public GameObject dandelion;
    public GameObject redRose;
    public bool flowerPlanted = false;
    GameObject flower;
    private Button plantButton;
    private Seeds seedsScript;
    //private bool flowerPresent = false;

    [HideInInspector]public string flowerName;
	[HideInInspector]public DateTime plantTime;
	[HideInInspector]public DateTime growTime;
	[HideInInspector]public Vector3 flowerPosition;


    private void Start()
    {
        plantButton = gameObject.GetComponent<Button>();
        seedsScript = GameObject.FindObjectOfType<Seeds>();
    }


    public void Click()
    {

        if (Seeds.seeds <= 0 || !Seeds.seedsActive || flowerPlanted)
        {
           return;
        } //else if () {

            float flowerX = gameObject.GetComponentInChildren<Image>().transform.localPosition.x;

            Vector3 flowerPosition = new Vector3(flowerX, this.transform.position.y + 35, this.transform.position.z);


            plantTime = DateTime.Now;
            //Debug.Log("planted at: " +plantTime);
            float randTier = UnityEngine.Random.value;
            float randFlower = UnityEngine.Random.value;
            //common
            if (randTier < 0.7f)
            { //should be 0.5
                if (randFlower < 0.33f)
                { //should be 0.33
                    this.flowerName = "Daisy";
                    growTime = plantTime.AddHours(2);
                    GameObject flower = Instantiate(daisy, flowerPosition, Quaternion.identity);
                    flower.transform.SetParent(this.transform, false);
                }
                else if (0.33f <= randFlower && randFlower < 0.66f)
                {
                    this.flowerName = "Red rose";
                    growTime = plantTime.AddHours(3);
                    GameObject flower = Instantiate(redRose, flowerPosition, Quaternion.identity);
                    flower.transform.SetParent(this.transform, false);
                }
                else if (0.66f <= randFlower && randFlower <= 1f)
                { //should be 0.66 in the beginning
                    this.flowerName = "Dandelion";
                    growTime = plantTime.AddHours(1);
                    GameObject flower = Instantiate(dandelion, flowerPosition, Quaternion.identity);
                    flower.transform.SetParent(this.transform, false);
                }
            }
            //normal
            if (randTier >= 0.7f && randTier < 0.9f)
            {
                if (randFlower < 0.33f)
                {
                    this.flowerName = "Pink rose";
                    growTime = plantTime.AddHours(5);
                }
                else if (0.33f <= randFlower && randFlower < 0.66f)
                {
                    this.flowerName = "Tulip";
                    growTime = plantTime.AddHours(7);
                }
                else if (0.66f <= randFlower && randFlower <= 1f)
                {
                    this.flowerName = "Narcissus";
                    growTime = plantTime.AddHours(7);
                }
            }
            //rare
            if (randTier >= 0.9f && randTier <= 1f)
            {
                if (randFlower < 1f)
                {
                    this.flowerName = "Black rose";
                    growTime = plantTime.AddHours(12);
                }
            }
        //very rare TODO later, change value of rare tier
        //this.name = "";

        //Debug.Log(this.flowerName);
        //Debug.Log("Will grow at: " +growTime);

        flowerPlanted = true;
            //plantButton.enabled = false;
            seedsScript.UseSeeds();

            //  Gamplay.UpdateFlowers();
            //flowersPresent = true;
      //  }
    }
}
