using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour {

    [SaveMember]
    public RectTransform here;
   [SaveMember]
    public Vector3 positionShelf;
    [SaveMember]
    public Vector3 scaleShelf;


    private void Start()
    {
        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
          positionShelf = here.position;
            scaleShelf = here.localScale;
        }
        here.position = positionShelf;
        here.localScale = scaleShelf;
    }
}
