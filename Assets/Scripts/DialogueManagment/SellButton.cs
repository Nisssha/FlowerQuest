using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    public string flowerName;
    public DialogueManager box;
    public string sympathyPerson;
    public int sympathyValue;
    public string buttonText;

    private StoryState storyState;
    private Inventory inventory;

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
        buttonText = newText;
    }

    public void Check()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        if (!inventory.CheckAvailabilitySingle(flowerName) && flowerName != "none")
            {
                this.gameObject.GetComponent<Button>().enabled = false;

                this.GetComponentInChildren<Text>().text = "Not enough flowers!";
            }
    }


    public void SetOption(string newOption)
    {
        this.flowerName = newOption;
    }

    public void ParseOption()
    {
        if (buttonText == "Wait")
        {
            HoldOnDialogue HoldOn = GameObject.FindObjectOfType<HoldOnDialogue>();
            HoldOn.WaitForFlowers();
            //box.lineNum++;
            //box.ShowDialogue();
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

        if (inventory.CheckAvailabilitySingle(flowerName))
        {
            inventory.RemoveOneItem(flowerName);
        }
        else
        {
            Debug.Log("Not enough flowers!");
            this.enabled = false;
            this.GetComponentInChildren<Text>().text = "Not enough flowers!";
        }


        //flowerName = all - should get all names from inventory and giva a drop-down menu (??????????) 


        //move to next line
        //Debug.Log(box.lineNum + " " + flowerName);
        box.lineNum++;
        //box.ClearButtons();
        //Debug.Log(box.lineNum + " " + flowerName);
        box.ShowDialogue();
    }
}
