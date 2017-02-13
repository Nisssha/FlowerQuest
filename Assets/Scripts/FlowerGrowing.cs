using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FlowerGrowing : MonoBehaviour {

    public Sprite[] sprites;
    public Image flowerImage;
    private Button picking;

    bool firstGrowDone = false;
    bool secondGrowDone = false;
    bool picked = false;
    DateTime pickingTime;

    int currentSprite = 0;

    private void Start()
    {
        picking = gameObject.GetComponent<Button>();
        picking.enabled = false;
        flowerImage = gameObject.GetComponent<Image>();
        InvokeRepeating("CheckGrowth", 1.0f, 1.0f);
    }


    void CheckGrowth()
    {
                Planting growthManagment = GetComponentInParent<Planting>();

                TimeSpan timeToGrow = (growthManagment.growTime - growthManagment.plantTime);
       
                int hoursToGrow = timeToGrow.Hours;
                int minutesToGrow = timeToGrow.Minutes;
                int secondsToGrow = timeToGrow.Seconds;

                int totalSecondsToGrow = timeToGrow.Hours * 60 * 60 + timeToGrow.Minutes * 60 + timeToGrow.Seconds;
                int thirdsecondsToGrow = totalSecondsToGrow / 20; // /2
                int twothirdsecondsToGrow = totalSecondsToGrow / 40; // /3

        DateTime regrow = pickingTime.AddSeconds(twothirdsecondsToGrow);

        DateTime firstGrow = growthManagment.plantTime.AddSeconds(thirdsecondsToGrow);
        DateTime secondGrow = growthManagment.plantTime.AddSeconds(twothirdsecondsToGrow);


                if (DateTime.Now.CompareTo(firstGrow) == 1 && !firstGrowDone && !picked)
                {
                    ChangeSprite();
                    firstGrowDone = true;
                }
                else if (DateTime.Now.CompareTo(secondGrow) == 1 && !secondGrowDone && !picked)
                {
                    ChangeSprite();
                    secondGrowDone = true;
                    picking.enabled = true;
                } else if (picked && DateTime.Now.CompareTo(regrow) == 1)
                {
                picked = false;
                picking.enabled = true;
                secondGrowDone = true;
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
        currentSprite--;
        flowerImage.sprite = sprites[currentSprite];
        secondGrowDone = false;
        picking.enabled = false;
        picked = true;
        pickingTime = DateTime.Now;
    }
}
