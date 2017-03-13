using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item {
    public Sprite sprite;
    public string nameFlower;


    public Item(Sprite image, string newName)
    {
        sprite = image;
       // Debug.Log(sprite);
        nameFlower = newName;
       // Debug.Log(nameFlower);
    }

  public Item()
    {
        sprite = null;
        nameFlower = "none";
    }
}
