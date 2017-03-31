using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shelf : MonoBehaviour {

    [SaveMember]
    public RectTransform here;
   [SaveMember]
    public Vector3 positionShelf;
    [SaveMember]
    public Vector3 scaleShelf;

    private float ScreenWidthSave;
    private float ScreenHeightSave;


    private void Start()
    {
        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionShelf = here.position;
            scaleShelf = here.localScale;
            ScreenWidthSave = Screen.width;
            ScreenHeightSave = Screen.height;
        }

        float currentWidth = Screen.width;
        float currentHeight = Screen.height;

        if (currentHeight != ScreenHeightSave && currentWidth != ScreenWidthSave)
        {
            float ratioH =  currentHeight/ ScreenHeightSave;
            float ratioW =  currentWidth/ ScreenWidthSave;
            Debug.Log(ratioH);

            here.position = new Vector3(positionShelf.x * ratioW, positionShelf.y * ratioH, positionShelf.z);
            here.localScale = new Vector3(scaleShelf.x * 1/ratioW, scaleShelf.y * 1/ratioH, positionShelf.z);
        }else
        {
            here.position = positionShelf;
            here.localScale = scaleShelf;
        }
    }
}
