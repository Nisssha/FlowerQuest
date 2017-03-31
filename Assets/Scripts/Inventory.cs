using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public int numItemSlots = 10;
    public Image[] itemImages;
    public Text[] itemText;
    public Text[] itemName;
    [SaveMember]public int[] amount;
    [SaveMember]public string[] flowerNames;


    [SaveMember]
    public RectTransform here;
    [SaveMember]
    public Vector3 positionInventory;
    [SaveMember]
    public Vector3 scaleInventory;

    public void Start()
    {
        if (here == null)
        {
            here = gameObject.GetComponent<RectTransform>();
            positionInventory = here.localPosition;
            scaleInventory = here.localScale;
        }
        here.localPosition = positionInventory;
        here.localScale = scaleInventory;

        if (amount.Length == 0)
        {
            amount = new int[numItemSlots];
        }
        itemImages = new Image[numItemSlots];
        itemText = new Text[numItemSlots];
        itemName = new Text[numItemSlots];
        if (flowerNames.Length == 0)
        {
            flowerNames = new string[numItemSlots];
        }
    } 

    public void Update()
    {
        if (itemImages[numItemSlots - 1] == null)
        {
            Slot[] slots = gameObject.GetComponentsInChildren<Slot>();

            for (int i = 0; i < numItemSlots; i++)
            {
                itemImages[i] = slots[i].GetComponentInChildren<ItemImage>().GetComponent<Image>();

                Text[] texts = slots[i].GetComponentsInChildren<Text>();

                foreach (Text slot in texts)
                {
                    if (slot.tag == "FlowerName")
                    {
                        itemName[i] = slot;
                    }
                    else
                    {
                        itemText[i] = slot;
                    }
                }

                if (amount[i] != 0)
                {
                    SpriteBank bank = GameObject.FindObjectOfType<SpriteBank>();
                    itemImages[i].sprite = bank.SetSprites(flowerNames[i])[2];
                    itemName[i].text = flowerNames[i].ToString();
                    itemImages[i].enabled = true;
                    itemText[i].text = amount[i].ToString();
                }
            }
        }
    }

    // ADD DISPLAYING FLOWER NAMES
    public void AddItem(Sprite image, string nameFlower)
    {
        for (int i = 0; i < 4; i++)
        {
            GetSlots();
        
            if (itemImages[i].sprite != null && itemImages[i].sprite == image)
            {
                amount[i]++;
                itemName[i].text = nameFlower;
                itemText[i].text = amount[i].ToString();

                return;
            }
            else if (itemImages[i].sprite == null)   
            {
                itemImages[i].sprite = image;
                itemImages[i].enabled = true;
                itemName[i].text = nameFlower;
                flowerNames[i] = nameFlower;
                amount[i] = 1;
                itemText[i].text = amount[i].ToString();
                return;    
            }     
    }    
}

    public void RemoveOneItem(string flowerToSell)
    {
        for (int i = 0; i < numItemSlots; i++)
        {
            GetSlots();
            if (flowerNames[i] == flowerToSell)
            {
                amount[i]--;
                itemText[i].text = amount[i].ToString();
            }
        }
    }

    public void RemoveMultipleItems(string[] flowerToSell, int[] amountRequested)
    {
        for (int i = 0; i <= flowerToSell.Length - 1; i++)
        {
            GetSlots();
            Debug.Log("Loop number" + i);
            Debug.Log("Looking for: " + flowerToSell[i] + " in amount of " + amountRequested[i]);

            for (int j = 0; j < numItemSlots; j++)
            {
                if (flowerNames[j] == null || flowerNames[j] != flowerToSell[i])
                {
                    continue;
                }
                if (flowerNames[j] == flowerToSell[i] && amount[j] >= amountRequested[i])
                {
                    Debug.Log("Found flower in inventory, remove " + amountRequested[i] + flowerToSell[i]);
                    amount[j] = amount[j] - amountRequested[i];
                    itemText[j].text = amount[j].ToString();
                    break;
                }
            }
        }
    }

    public bool CheckAvailabilitySingle(string flowerToSell)
    {
        for (int i = 0; i < numItemSlots; i++)
        {
            GetSlots();
            
            if (flowerNames[i] == flowerToSell)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckAvailabilityMultiple(string[] flowerToSell, int[] amountRequested)
    {
        
        bool avialable = true;
        for (int i = 0; i <= flowerToSell.Length - 1; i++)
        {
            GetSlots();
            Debug.Log("Loop number" + i);
            Debug.Log("Looking for: " + flowerToSell[i] + " in amount of " + amountRequested[i]);
            
            for (int j = 0; j < numItemSlots; j++)
            {
                if (!avialable)
                {
                    Debug.Log("Not found flower in inventory, returning false");
                    return avialable;
                }

                if(flowerNames[j] == null)
                {
                    if (j == numItemSlots - 1)
                    {
                        Debug.Log("Last position empty and still looking - return false");
                        return false;
                    }
                    Debug.Log("Position empty and still looking - jumping position");
                    continue;
                }
                
                Debug.Log("In position " + j + " there is a " + flowerNames[j] + " in amount of " + amount[j]);
                if (flowerNames[j] == flowerToSell[i] && amount[j] >= amountRequested[i])
                {
                    Debug.Log("Found flower in inventory, returning true");
                    avialable = true;
                    break;
                }
                else if(flowerNames[j] == flowerToSell[i] && amount[j] < amountRequested[i])
                {
                    Debug.Log(flowerToSell[i] + " not avialable in requested amount");
                    avialable = false;
                    continue;
                }
                else if(flowerNames[j] != flowerToSell[i] && j == 3)
                {
                    Debug.Log(flowerToSell[i] + " not avialable at all");
                    avialable = false;
                }
            }
        }
            return avialable;
    }

    void GetSlots()
    {
        for (int i = 0; i < numItemSlots; i++)
        {
            if (itemImages[i] == null)
            {
                Slot[] slots = gameObject.GetComponentsInChildren<Slot>();
                {
                    itemImages[i] = slots[i].GetComponentInChildren<ItemImage>().GetComponent<Image>();
                    itemText[i] = slots[i].GetComponentInChildren<Text>();
                }
            }
        }
    }
}
