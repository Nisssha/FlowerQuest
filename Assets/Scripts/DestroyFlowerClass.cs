using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFlowerClass : MonoBehaviour {

    public static bool destroyActive = false;


    public void ActivateDestroyFunction()
    {

        destroyActive = true;
        Debug.Log("Destroy active: " + destroyActive);
    }

    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionButton;

    void Start()
    {

        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionButton = here.localPosition;
        }
        here.localPosition = positionButton;

    }
}
