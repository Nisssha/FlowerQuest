using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class FlowerGrowing : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

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

    bool firstGrowDone = false;
    bool secondGrowDone = false;
    bool picked = false;
    bool pickable = false;
    bool hoover = false;
    DateTime pickingTime;
    public TimeSpan timeToGrow;


    int hoursToGrow;
    int minutesToGrow;
    int secondsToGrow;
    int totalSecondsToGrow;
    int thirdsecondsToGrow;
    int twothirdsecondsToGrow;

    DateTime regrow;
    DateTime firstGrow;
    DateTime secondGrow;

    int currentSprite = 0;
          
    private void Start()
    {
        hoover = false;

        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionFlower = here.localPosition;
        }

        here.localPosition = positionFlower;
    
        picking = gameObject.GetComponent<Button>();
                
        seedsScript = GameObject.FindObjectOfType<Seeds>();
        planting = gameObject.GetComponentInParent<Planting>();
        flowerImage = gameObject.GetComponentInChildren<Image>();


        timeToGrow = (planting.growTime - planting.plantTime);

        bank = GameObject.FindObjectOfType<SpriteBank>();
        sprites = bank.SetSprites(planting.flowerName);

        flowerImage.sprite = sprites[currentSprite];

        hoursToGrow = timeToGrow.Hours;
        minutesToGrow = timeToGrow.Minutes;
        secondsToGrow = timeToGrow.Seconds;

        totalSecondsToGrow = timeToGrow.Hours * 60 * 60 + timeToGrow.Minutes * 60 + timeToGrow.Seconds;
        thirdsecondsToGrow = totalSecondsToGrow / 2;
        twothirdsecondsToGrow = totalSecondsToGrow;


        firstGrow = planting.plantTime.AddSeconds(thirdsecondsToGrow);

        secondGrow = planting.plantTime.AddSeconds(twothirdsecondsToGrow);

        InvokeRepeating("CheckGrowth", 1.0f, 1.0f);
            }


    void CheckGrowth()
            {
        //changing time in hoover info about grow time (if hoover window is active)
            if (hoover)
        {
            Text TimePopUpText = gameObject.GetComponentInChildren<Text>();
            if (picked)
            {
                TimePopUpText.text = "Time to bloom\n" + ((regrow - DateTime.Now).Hours).ToString() + ":" + ((regrow - DateTime.Now).Minutes).ToString() + ":" + ((regrow - DateTime.Now).Seconds).ToString();
            }
            else
            {
                TimePopUpText.text = "Time to bloom\n" + ((planting.growTime - DateTime.Now).Hours).ToString() + ":" + ((planting.growTime - DateTime.Now).Minutes).ToString() + ":" + ((planting.growTime - DateTime.Now).Seconds).ToString();
            }
        }
            //flower grows first time
        if (DateTime.Now.CompareTo(firstGrow) == 1 && !firstGrowDone && !picked)
                        {
                            ChangeSprite();
                            firstGrowDone = true;
                        }
            //flower grows to pickable stage
                        else if (DateTime.Now.CompareTo(secondGrow) == 1 && !secondGrowDone && !picked)
                        {
                            ChangeSprite();
                            secondGrowDone = true;
                            pickable = true;
            //flower was already picked and it is possible to pick it again
                        } else if (picked && DateTime.Now.CompareTo(regrow) == 1)
                        {
                        picked = false;
                        secondGrowDone = true;
                        pickable = true;
                        ChangeSprite();
                         }
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

            //adding objects to inventory
            if (inventory == null)
            {
                inventory = GameObject.FindObjectOfType<Inventory>();
            }
            inventory.AddItem(sprites[currentSprite], planting.flowerName);
            currentSprite--;
            flowerImage.sprite = sprites[currentSprite];
            secondGrowDone = false;
            seedsScript = GameObject.FindObjectOfType<Seeds>();

            //randomize adding seeds

            if (UnityEngine.Random.value <= 0.3)
            {
                seedsScript.AddSeeds();
            }

            //setting the ability to pick flowers and time for another picking
            picked = true;
            pickable = false;
            pickingTime = DateTime.Now;
            regrow = pickingTime.AddSeconds(twothirdsecondsToGrow);
        }
            }

    //Destroying the flower if destroy button is active
            public void DestroyFlower()
            {
                if (DestroyFlowerClass.destroyActive)
                {
                    Debug.Log("Destroy if true");
                    planting.flowerPlanted = false;
                    Destroy(this.gameObject);
                }
            }

    //Managing the pop ups with time to grow

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoover = true;
        GameObject TimePopUp = Instantiate(Resources.Load("Prefabs/GrowTimePopUp")) as GameObject;
        TimePopUp.transform.SetParent(this.gameObject.transform, false);

        Text TimePopUpText = TimePopUp.GetComponent<Text>();
        if (picked)
        {
            TimePopUpText.text = "Time to bloom\n" + ((regrow - DateTime.Now).Hours).ToString() + ":" + ((regrow - DateTime.Now).Minutes).ToString() + ":" + ((regrow - DateTime.Now).Seconds).ToString();
        }
        else
        {
            TimePopUpText.text = "Time to bloom\n" + ((planting.growTime-DateTime.Now).Hours).ToString() + ":" + ((planting.growTime - DateTime.Now).Minutes).ToString() + ":" + ((planting.growTime - DateTime.Now).Seconds).ToString();
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        hoover = false;
        GameObject TimePopUp = gameObject.GetComponentInChildren<Text>().gameObject;
        Destroy(TimePopUp);
    }

    //speeding up growth

    public void SpeedUpGrowth(int seconds)
    {
        if (!picked)
        {
            timeToGrow = timeToGrow.Subtract(new TimeSpan(0, 0, seconds));

            Debug.Log("Time to grow: " +timeToGrow);
            hoursToGrow = timeToGrow.Hours;
            minutesToGrow = timeToGrow.Minutes;
            secondsToGrow = timeToGrow.Seconds;

            totalSecondsToGrow = timeToGrow.Hours * 60 * 60 + timeToGrow.Minutes * 60 + timeToGrow.Seconds;
            thirdsecondsToGrow = totalSecondsToGrow / 2;
            twothirdsecondsToGrow = totalSecondsToGrow;

            firstGrow = planting.plantTime.AddSeconds(thirdsecondsToGrow);

            secondGrow = planting.plantTime.AddSeconds(twothirdsecondsToGrow);
            return;
        }

        regrow.AddSeconds(-seconds);
        Debug.Log("regrow time: " + regrow);
    }


}
