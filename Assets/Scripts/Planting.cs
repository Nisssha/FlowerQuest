using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Planting : MonoBehaviour {
    
    [HideInInspector]public bool flowerPlanted = false;
       
    private Button plantButton;
    [DontSaveMember]private Seeds seedsScript;

    [HideInInspector]public string flowerName;
    [HideInInspector]public DateTime plantTime;
    [HideInInspector]public DateTime growTime;
    [HideInInspector]public Vector3 flowerPosition;

    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionShelf;
    [SaveMember]
    public Vector3 scaleShelf;

    private float ScreenWidthSave;
    private float ScreenHeightSave;


    private void Start()
    {
        //maintain position throught the save
        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionShelf = here.localPosition;
            scaleShelf = here.localScale;
            ScreenWidthSave = Screen.width;
            ScreenHeightSave = Screen.height;
        }

        float currentWidth = Screen.width;
        float currentHeight = Screen.height;

        if (currentHeight != ScreenHeightSave && currentWidth != ScreenWidthSave)
        {
            float ratioH = currentHeight / ScreenHeightSave;
            float ratioW = currentWidth / ScreenWidthSave;
            Debug.Log(ratioH);

            here.localPosition = new Vector3(positionShelf.x * ratioW, positionShelf.y * ratioH, positionShelf.z);
            here.localScale = new Vector3(scaleShelf.x * ratioW, scaleShelf.y * ratioH, positionShelf.z);
        }
        else
        {
            here.localPosition = positionShelf;
            here.localScale = scaleShelf;
        }

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
          return;
        } 
            float flowerX = gameObject.GetComponentInChildren<Image>().transform.localPosition.x;
            float flowerY = gameObject.GetComponentInChildren<Image>().transform.localPosition.y;

            Vector3 flowerPosition = new Vector3(flowerX, flowerY+80, this.transform.position.z);


            plantTime = DateTime.Now;
            float randTier = UnityEngine.Random.value;
            float randFlower = UnityEngine.Random.value;

        //common
        if (randTier < 0.7f)
        { 
            if (randFlower < 0.33f)
            { 
                this.flowerName = "Daisy";
                growTime = plantTime.AddMinutes(7);
                GameObject flower = Instantiate(Resources.Load("Daisy"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
            }
            else if (0.33f <= randFlower && randFlower < 0.66f)
            {
                this.flowerName = "Red rose";
                growTime = plantTime.AddMinutes(10);
                GameObject flower = Instantiate(Resources.Load("RedRose"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
            }
            else if (0.66f <= randFlower && randFlower <= 1f)
            { //should be 0.66 in the beginning
                this.flowerName = "Dandelion";
                growTime = plantTime.AddMinutes(5);
                GameObject flower = Instantiate(Resources.Load("Dandelion"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
            }
        }
        //normal
        if (randTier >= 0.7f && randTier < 0.8f)
        {
            if (randFlower < 0.33f)
            {
                this.flowerName = "Pink rose";
                growTime = plantTime.AddMinutes(15);
                GameObject flower = Instantiate(Resources.Load("PinkRose"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
        }
            else if (0.33f <= randFlower && randFlower < 0.66f)
            {
                this.flowerName = "Tulip";
                growTime = plantTime.AddMinutes(15);
                GameObject flower = Instantiate(Resources.Load("Tulip"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
        }
            else if (0.66f <= randFlower && randFlower <= 1f)
            {
                this.flowerName = "Narcissuss";
                growTime = plantTime.AddMinutes(20);
                GameObject flower = Instantiate(Resources.Load("Narcissuss"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
            }
        }
        //rare
        if (randTier >= 0.8f && randTier <= 0.93f)
        {
            if (randFlower <= 1f)
            {
                this.flowerName = "Black rose";
                growTime = plantTime.AddMinutes(40);
                GameObject flower = Instantiate(Resources.Load("BlackRose"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
            }
        }
        //very rare
        if (randTier >= 0.93f && randTier <= 1f)
        {
            if (randFlower <= 1f)
            {
                this.flowerName = "Moon rose";
                growTime = plantTime.AddMinutes(120);
                GameObject flower = Instantiate(Resources.Load("MoonRose"), flowerPosition, Quaternion.identity) as GameObject;
                flower.transform.SetParent(this.transform, false);
            }
        }

        //Debug.Log(this.flowerName);
        //Debug.Log("Will grow at: " +growTime);

        // GameObject thingy1 =  Instantiate(thingy, flowerPosition, Quaternion.identity);
        // thingy1.transform.SetParent(this.transform, false);

        flowerPlanted = true;
                //plantButton.enabled = false;
            seedsScript.UseSeeds();
            Sprite currentSprite = this.GetComponentInChildren<FlowerGrowing>().gameObject.GetComponentInChildren<Image>().sprite;
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
