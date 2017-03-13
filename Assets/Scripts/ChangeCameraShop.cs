using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraShop : MonoBehaviour {

    public Camera gardenCamera;
    public Camera shopCamera;
    public Canvas garden;
    public Canvas shop;

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
        }
    }

    public void GoToGarden()
    {
        /*
        if (gardenCamera == null)
        {
            gardenCamera = GameObject.Find("Garden Camera").GetComponent<Camera>();
        }
        if (shopCamera == null)
        {
            shopCamera = GameObject.Find("Shop Camera").GetComponent<Camera>();
        }

        if (garden == null)
        {
            garden = GameObject.Find("Garden").GetComponent<Canvas>();
        }
        if (shop == null)
        {
            shop = GameObject.Find("Shop").GetComponent<Canvas>();
        }
        */
        garden.enabled = true;
        shop.enabled = false;

        gardenCamera.enabled = true;
        shopCamera.enabled = false;
        // gardenCamera.gameObject.SetActive(true);
        // shopCamera.gameObject.SetActive(false);
    }
}