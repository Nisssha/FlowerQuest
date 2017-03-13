using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Planting : MonoBehaviour {

    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionPot;
    [SaveMember]
    public Vector3 scalePot;

   

        [HideInInspector]public bool flowerPlanted = false;
       // GameObject flower;
       
        private Button plantButton;
       [DontSaveMember]private Seeds seedsScript;
        //private bool flowerPresent = false;

        [HideInInspector]public string flowerName;
        [HideInInspector]public DateTime plantTime;
        [HideInInspector]public DateTime growTime;
        [HideInInspector]public Vector3 flowerPosition;

    /*
    private void Awake()
    {
        seedsScript = GameObject.FindObjectOfType<Seeds>();
     //   Debug.Log("Seeds script: " + seedsScript);
    }
    */

    private void Start()
        {
      //  Debug.Log(here);
            if (here == null)
                {
                here = gameObject.GetComponent<RectTransform>();
                positionPot = here.localPosition;
                }
       // Debug.Log(gameObject + " start called");
            here.localPosition = positionPot;

             plantButton = gameObject.GetComponent<Button>();
             
    }


    
    

        public void Click()
        {
        if(seedsScript == null)
        {
            seedsScript = GameObject.FindObjectOfType<Seeds>();
        }

         if (seedsScript.seeds <= 0 || !Seeds.seedsActive || flowerPlanted) 
        {
            Debug.Log("seedsScript.seeds " + seedsScript.seeds);
            Debug.Log("Seeds.seedsActive " + Seeds.seedsActive);
            Debug.Log("retur");
               return;
            } //else if () {

                float flowerX = gameObject.GetComponentInChildren<Image>().transform.localPosition.x;
                float flowerY = gameObject.GetComponentInChildren<Image>().transform.localPosition.y;

            Vector3 flowerPosition = new Vector3(flowerX, flowerY+140, this.transform.position.z);


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
                GameObject flower = Instantiate(Resources.Load("Daisy"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
                    }
                    else if (0.33f <= randFlower && randFlower < 0.66f)
                    {
                        this.flowerName = "Red rose";
                        growTime = plantTime.AddHours(3);
                GameObject flower = Instantiate(Resources.Load("RedRose"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
                    }
                    else if (0.66f <= randFlower && randFlower <= 1f)
                    { //should be 0.66 in the beginning
                        this.flowerName = "Dandelion";
                        growTime = plantTime.AddHours(1);
                GameObject flower = Instantiate(Resources.Load("Dandelion"), flowerPosition, Quaternion.identity) as GameObject;
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
                GameObject flower = Instantiate(Resources.Load("PinkRose"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
                }
                    else if (0.33f <= randFlower && randFlower < 0.66f)
                    {
                        this.flowerName = "Tulip";
                        growTime = plantTime.AddHours(7);
                GameObject flower = Instantiate(Resources.Load("Tulip"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
                }
                    else if (0.66f <= randFlower && randFlower <= 1f)
                    {
                        this.flowerName = "Narcissuss";
                        growTime = plantTime.AddHours(7);
                GameObject flower = Instantiate(Resources.Load("Narcissuss"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
                }
                }
                //rare
                if (randTier >= 0.9f && randTier <= 1f)
                {
                    if (randFlower < 1f)
                    {
                        this.flowerName = "Black rose";
                        growTime = plantTime.AddHours(12);
                    GameObject flower = Instantiate(Resources.Load("BlackRose"), flowerPosition, Quaternion.identity) as GameObject;
                    flower.transform.SetParent(this.transform, false);
                }
                }
            //very rare TODO later, change value of rare tier
            //this.name = "";

            //Debug.Log(this.flowerName);
            //Debug.Log("Will grow at: " +growTime);

          // GameObject thingy1 =  Instantiate(thingy, flowerPosition, Quaternion.identity);
           // thingy1.transform.SetParent(this.transform, false);

            flowerPlanted = true;
                //plantButton.enabled = false;
            seedsScript.UseSeeds();
            Sprite currentSprite = this.GetComponentInChildren<FlowerGrowing>().gameObject.GetComponent<Image>().sprite;
            // Debug.Log(currentSprite);
            FlowerItem flowerSave = new FlowerItem(this.flowerName, this.plantTime, this.growTime, this.flowerPosition, currentSprite);

          //  Debug.Log("Flower save: " +flowerSave);
            //Game.UpdateFlowers();
            //Game();

                //  Gamplay.UpdateFlowers();
                //flowersPresent = true;
          //  }
        }

        
}
