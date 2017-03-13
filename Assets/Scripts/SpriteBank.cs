using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBank : MonoBehaviour
{
    public Sprite[] blackRose = new Sprite[3];
    public Sprite[] pinkRose = new Sprite[3];
    public Sprite[] redRose = new Sprite[3];
    public Sprite[] dandelion = new Sprite[3];
    public Sprite[] narcissuss = new Sprite[3];
    public Sprite[] tulip = new Sprite[3];
    public Sprite[] daisy = new Sprite[3];

    public Sprite[] SetSprites (string flowerName)
    {
        if (flowerName == "Daisy")
        {
            return daisy;
        }else if (flowerName == "Dandelion")
        {
            return dandelion;
        }
        else if (flowerName == "Tulip")
        {
            return tulip;
        }
        else if (flowerName == "Narcissuss")
        {
            return narcissuss;
        }
        else if (flowerName == "Red rose")
        {
            return redRose;
        }
        else if (flowerName == "Black rose")
        {
            return blackRose;
        }
        else if (flowerName == "Pink rose")
        {
            return pinkRose;
        }else { throw new Exception("name not found"); }
    }


    
    
}
