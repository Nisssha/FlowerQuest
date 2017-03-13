using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour {

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

    public void DeactivateButtons()
    {
        Seeds.seedsActive = false;
        DestroyFlowerClass.destroyActive = false;
    }
}
