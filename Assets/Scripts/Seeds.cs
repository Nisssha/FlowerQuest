using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seeds : MonoBehaviour {

    [SaveMember]public int seeds;
    public static bool seedsActive = false;

    private Text itemText;
    public bool newGame = true;


    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionButton;


    // Use this for initialization
    void Start () {

        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionButton = here.localPosition;
        }
        here.localPosition = positionButton;

        itemText = gameObject.GetComponentInChildren<Text>();
        itemText.text = seeds.ToString();
    }

    private void Awake()
    {
        if (newGame)
        {
            seeds = 10; //final: 5
            newGame = false;
        }
    }


    public void UseSeeds()
    {
        itemText = gameObject.GetComponentInChildren<Text>();
        seeds--;
        itemText.text = seeds.ToString();
    }

    public void AddSeeds()
    {
        itemText = gameObject.GetComponentInChildren<Text>();
        seeds++;
        itemText.text = seeds.ToString();
    }

    public void ActivateSeedsFunction()
    {
        seedsActive = true;
    }
}
