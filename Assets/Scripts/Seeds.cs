using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seeds : MonoBehaviour {

    [SaveMember]public int seeds;
    public static bool seedsActive = false;

    private Text itemText;
    public bool newGame = true; //TODO put it somwhere else


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
        itemText.text = "Seeds: " + seeds.ToString();
    }

    private void Awake()
    {
        if (newGame)
        {
            seeds = 13;
            newGame = false;
        }
        /*
        Debug.Log(itemText + " itemText");
        if (itemText == null)
        {
            itemText = gameObject.GetComponentInChildren<Text>();
            itemText.text = "Seeds: " + seeds.ToString();
            Debug.Log(itemText.text);
        }
        */
    }


    public void UseSeeds()
    {
        itemText = gameObject.GetComponentInChildren<Text>();
        seeds--;
        itemText.text = "Seeds: " + seeds.ToString();
    }

    public void AddSeeds()
    {
        Debug.Log(gameObject.GetComponent<Seeds>());
        itemText = gameObject.GetComponentInChildren<Text>();
        seeds++;
        itemText.text = "Seeds: " + seeds.ToString();
    }

    public void ActivateSeedsFunction()
    {

        seedsActive = true;
        Debug.Log("Seeds active: " + seedsActive);
    }

    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !seedsActive)
        {
            seedsActive = true;
            Debug.Log("Seeds active: " + seedsActive);
        }else if (Input.GetMouseButtonDown(0) && seedsActive)
        {
            seedsActive = false;
            Debug.Log("Seeds active: " + seedsActive);
        }
    }
    */


}
