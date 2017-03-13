using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FlowerGrowing : MonoBehaviour {

    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionFlower;
 
            public Sprite[] sprites;
            public Image flowerImage;
            public SpriteBank bank;

    private Button picking;
                [DontSaveMember]private Seeds seedsScript;
                private Planting planting;
                private Inventory inventory;
              //  private Transform flowerTransform;

                bool firstGrowDone = false;
                bool secondGrowDone = false;
                bool picked = false;
                bool pickable = false;
                DateTime pickingTime;
                TimeSpan timeToGrow;

                int currentSprite = 0;
          
    private void Start()
    {

        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionFlower = here.localPosition;
        }

        here.localPosition = positionFlower;
    
                //flowerTransform = gameObject.GetComponent<Transform>();
                picking = gameObject.GetComponent<Button>();
                
                seedsScript = GameObject.FindObjectOfType<Seeds>();
                planting = gameObject.GetComponentInParent<Planting>();
               // picking.enabled = false;
                flowerImage = gameObject.GetComponent<Image>();


                timeToGrow = (planting.growTime - planting.plantTime);

        bank = GameObject.FindObjectOfType<SpriteBank>();
        sprites = bank.SetSprites(planting.flowerName);

        flowerImage.sprite = sprites[currentSprite];


        InvokeRepeating("CheckGrowth", 1.0f, 1.0f);
            }


            void CheckGrowth()
            {
                      //  Planting planting = GetComponentInParent<Planting>();

                        int hoursToGrow = timeToGrow.Hours;
                        int minutesToGrow = timeToGrow.Minutes;
                        int secondsToGrow = timeToGrow.Seconds;

                        int totalSecondsToGrow = timeToGrow.Hours * 60 * 60 + timeToGrow.Minutes * 60 + timeToGrow.Seconds;
                        int thirdsecondsToGrow = totalSecondsToGrow / 60; // /2
                        int twothirdsecondsToGrow = totalSecondsToGrow / 40; // /3

                DateTime regrow = pickingTime.AddSeconds(twothirdsecondsToGrow);

                DateTime firstGrow = planting.plantTime.AddSeconds(thirdsecondsToGrow);

                DateTime secondGrow = planting.plantTime.AddSeconds(twothirdsecondsToGrow);


        if (DateTime.Now.CompareTo(firstGrow) == 1 && !firstGrowDone && !picked)
                        {
                            ChangeSprite();
                            firstGrowDone = true;
                        }
                        else if (DateTime.Now.CompareTo(secondGrow) == 1 && !secondGrowDone && !picked)
                        {
                            ChangeSprite();
                            secondGrowDone = true;
                    //  picking.enabled = true;
                            pickable = true;
                        } else if (picked && DateTime.Now.CompareTo(regrow) == 1)
                        {
                        picked = false;
            // picking.enabled = true;
                        secondGrowDone = true;
                        pickable = true;
                        ChangeSprite();
                         }
               // Game.UpdateFlowersGrowing(this);
            }

            public void ChangeSprite()
            {
                currentSprite++;
                flowerImage.sprite = sprites[currentSprite];
            }

            public void PickingFlower()
            {
                if (pickable)
                {

            //  Item instanceFlower = new Item(sprites[currentSprite], planting.flowerName);
            /*
                   Debug.Log( instanceFlower.sprite);
                    //instanceFlower.nameFlower = planting.flowerName;
                    inventory.AddItem(instanceFlower);
                    */

            //Item instanceFlower = ScriptableObject.CreateInstance<Item>();
            // instanceFlower.nameFlower = planting.flowerName;
            // instanceFlower.sprite = sprites[currentSprite];
            if (inventory == null)
            {
                inventory = GameObject.FindObjectOfType<Inventory>();
            }
            inventory.AddItem(sprites[currentSprite], planting.flowerName);


            currentSprite--;
                    flowerImage.sprite = sprites[currentSprite];
                    secondGrowDone = false;
            //picking.enabled = false;
            seedsScript = GameObject.FindObjectOfType<Seeds>();
            Debug.Log("Picking flower - seedsScript: " + seedsScript);
            seedsScript.AddSeeds();
                    picked = true;
                    pickable = false;
                    pickingTime = DateTime.Now;
                    //FlowerItem flowerInstance = new FlowerItem(planting.flowerName, planting.plantTime, planting.growTime, planting.flowerPosition);
                }
            }

            public void DestroyFlower()
            {
                Debug.Log("Destroy called");
                if (DestroyFlowerClass.destroyActive)
                {
                    Debug.Log("Destroy if true");
                    //GameObject flowerToDie = gameObject.GetComponentInParent<Planting>().GetComponentInChildren<FlowerGrowing>();
                    // Destroy(flowerToDie);
                    planting.flowerPlanted = false;
                    Destroy(this.gameObject);
                }
            }
            
    }
