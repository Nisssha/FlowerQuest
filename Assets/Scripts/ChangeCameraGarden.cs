using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraGarden : MonoBehaviour {

    public Camera gardenCamera;
    public Camera shopCamera;
    public Canvas garden;
    public Canvas shop;
    public bool gardenActive = true;

    private void Update()
    {
        if (gardenCamera == null)
        {
            gardenCamera = GameObject.Find("Garden Camera").GetComponent<Camera>();
            shopCamera = GameObject.Find("Shop Camera").GetComponent<Camera>();

            garden = GameObject.Find("Garden").GetComponent<Canvas>();
            shop = GameObject.Find("Shop").GetComponent<Canvas>();

            garden.enabled = true;
            shop.enabled = false;

            gardenCamera.enabled = true;
            shopCamera.enabled = false;
            gardenActive = true;
        }
    }

    public void GoToShop()
    {
        garden.enabled = false;
        shop.enabled = true;

        gardenCamera.enabled = false;
        shopCamera.enabled = true;

        gardenActive = false;
    }

    public void GoToGarden()
    {
        garden.enabled = true;
        shop.enabled = false;

        gardenCamera.enabled = true;
        shopCamera.enabled = false;

        gardenActive = true;
        Debug.Log("Garden active: " + gardenActive);
    }
}
