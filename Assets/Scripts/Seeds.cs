using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seeds : MonoBehaviour {

    public static int seeds = 10;
    public static bool seedsActive = false;
    private Text itemText;

    // Use this for initialization
    void Start () {
        itemText = gameObject.GetComponentInChildren<Text>();
        itemText.text = "Seeds: " + seeds.ToString();
    }

    public void UseSeeds()
    {
        seeds--;
        itemText.text = "Seeds: " + seeds.ToString();
    }

    public void AddSeeds()
    {
        seeds++;
        itemText.text = "Seeds: " + seeds.ToString();
    }

    private void OnMouseDown()
    {
        seedsActive = true;
    }
}
