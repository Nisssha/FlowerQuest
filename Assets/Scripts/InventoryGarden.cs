using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGarden : MonoBehaviour {

    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionInventory;
    [SaveMember]
    public Vector3 scaleInventory;


    private void Start()
    {
        //  Debug.Log(here);
        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionInventory = here.localPosition;
            scaleInventory = here.localScale;
        }
        // Debug.Log(gameObject + " start called");
        here.localPosition = positionInventory;
        here.localScale = scaleInventory;
    }

    }
