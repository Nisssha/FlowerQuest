using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamplay : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            //SaveLoad.Save();
           // Game.current = new Game();
            Debug.Log("Save called");
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            //SaveLoad.Load();
            Debug.Log("Load called");
        }
    }

}
