using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFlowerClass : MonoBehaviour {

    public static bool destroyActive = false;


   

    private void OnMouseDown()
    {
        destroyActive = true;
    }
}
