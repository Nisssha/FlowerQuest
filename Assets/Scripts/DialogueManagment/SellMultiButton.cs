using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellMultiButton : MonoBehaviour
{
    public string[] flowerName;
    public int[] flowerAmount;
    public int numberOfTypes;
    public DialogueManager box;
    public string sympathyPerson;
    public int sympathyValue;
    public string buttonText;

    private StoryState storyState;
    private Inventory inventory;

    //ADD EABLING/DISABLING due to avialability

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
        buttonText = newText;
    }

    public void Check()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        if (!inventory.CheckAvailabilityMultiple(flowerName, flowerAmount) && flowerName[0] != "Wait")
        {
            Debug.Log("Not enough flowers!");
            this.enabled = false;
            this.GetComponentInChildren<Text>().text = "Not enough flowers!";
        }
    }


    public void ParseOption()
    {
        if (buttonText == "Wait")
        {
            HoldOnDialogue HoldOn = GameObject.FindObjectOfType<HoldOnDialogue>();
            HoldOn.WaitForFlowers();
            return;
        }

        box.playerTalking = false;
        storyState = GameObject.FindObjectOfType<StoryState>();
        inventory = GameObject.FindObjectOfType<Inventory>();

        //change sympathy value - set none to do nothing
        if (sympathyPerson != "none")
        {
            storyState.SetSympathy(sympathyPerson, sympathyValue);
        }

        //check if requested item is avialable and remove one from inventory if possible, if not - disable button

        if (inventory.CheckAvailabilityMultiple(flowerName, flowerAmount))
        {
            inventory.RemoveMultipleItems(flowerName, flowerAmount);
        }
        else
        {
            Debug.Log("Not enough flowers!");
            this.enabled = false;
            this.GetComponentInChildren<Text>().text = "Not enough flowers!";
        }


        //flowerName = all - should get all names from inventory and giva a drop-down menu (??????????) 


        box.lineNum++;
        box.ShowDialogue();
    }

    
}
