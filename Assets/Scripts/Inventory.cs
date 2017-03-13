using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public const int numItemSlots = 4;
    public Image[] itemImages;                           // = new Image[numItemSlots];
    //[SaveMember]public List<Item> items; // = new List<Item>();                          // public Item[] items = new Item[numItemSlots];
    public Text[] itemText;                                // = new Text[numItemSlots];
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

        //Debug.Log(flowerNames.Length);
        //Debug.Log(amount.Length);

        if (amount.Length == 0)
        {
            amount = new int[4];
        }
        itemImages = new Image[4];
        itemText = new Text[4];
        if (flowerNames.Length == 0)
        {
            flowerNames = new string[4];
        }

        




            /*
            //items = new Item[4];
            Debug.Log("Item count: " + items.Count);

            if (items.Count == 0)
            {
                Debug.Log("items were null");
                List<Item> items = new List<Item>();
             }

    /*
            for (int i = 0; i < 4; i++)
            {
                if(i == items.Count)
                {
                    /*
                    Item instanceFlower = ScriptableObject.CreateInstance<Item>();
                    instanceFlower.nameFlower = "none";
                    instanceFlower.sprite = null;

                    Item instanceFlower = new Item();
                    items.Add(instanceFlower);
                    Debug.Log("Item count: " + items.Count);
                    //items[i] = new Item();
                }
            }

    */
        }

    public void Update()
    {
        if (itemImages[3] == null)
        {
            //Debug.Log("itemImages[3] == null");
            //  Image[] slotsImage = gameObject.GetComponentsInChildren<Image>();
            // should be private and found in children when run, we can loose background image for easier work

            // ObjectIdentifier[] slots = gameObject.GetComponentsInChildren<ObjectIdentifier>();
            Slot[] slots = gameObject.GetComponentsInChildren<Slot>();
            //foreach (Slot slot in slots)
            for (int i = 0; i < numItemSlots; i++)
            {
                //Debug.Log(slots[i].GetComponent<ItemImage>());
                itemImages[i] = slots[i].GetComponentInChildren<ItemImage>().GetComponent<Image>();

                //itemImages = slot.GetComponentInChildren<ItemImage>().GetComponent<Image>();
                // Debug.Log(itemImages[i]);

                itemText[i] = slots[i].GetComponentInChildren<Text>();

                if (amount[i] != 0)
                {
                    SpriteBank bank = GameObject.FindObjectOfType<SpriteBank>();
                    itemImages[i].sprite = bank.SetSprites(flowerNames[i])[2];
                    itemImages[i].enabled = true;
                    //Debug.Log(bank.SetSprites(flowerNames[i])[2]);
                    itemText[i].text = amount[i].ToString();
                }
                // itemText = slot.GetComponentInChildren<Text>();
                //  Debug.Log(itemText[i]);

            }
        }
    }



    // public void AddItem(Item itemToAdd)
    public void AddItem(Sprite image, string nameFlower)
    {
        // Debug.Log(itemToAdd);
        //  Debug.Log(itemToAdd.sprite);
        // Debug.Log(items[0].sprite);
        
   
        //TODO make flowername lists on positions (can display them as well)
        
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(itemImages[i]);


            if (itemImages[i] == null)
            {
                Slot[] slots = gameObject.GetComponentsInChildren<Slot>();

                {
                    itemImages[i] = slots[i].GetComponentInChildren<ItemImage>().GetComponent<Image>();

                    itemText[i] = slots[i].GetComponentInChildren<Text>();
                }
            }


                //TODO add checking all the positions for duplicate
                //if (items[i].sprite != null && itemToAdd.nameFlower == items[i].nameFlower)
                if (itemImages[i].sprite != null && itemImages[i].sprite == image)
            {
                Debug.Log("Should stack now");
                amount[i]++;
                Debug.Log("Number of " + nameFlower + " on inventory position: " + i + " is " + amount[i]);
                itemText[i].text = amount[i].ToString();

                return;
            }
            else if (itemImages[i].sprite == null)   
            {
                Debug.Log("should do new item");
               // items[i] = itemToAdd;
                itemImages[i].sprite = image;
                itemImages[i].enabled = true;
                flowerNames[i] = nameFlower;
                amount[i] = 1;
                itemText[i].text = amount[i].ToString();
                return;    
            }     
    }    
}
    /*
public void RemoveItem(Item itemToRemove)
{
    for (int i = 0; i < items.Length; i++)
    {
        if (items[i] == itemToRemove)
        {
            items[i] = null;
            itemImages[i] = null;
            itemImages[i].enabled = false;
            return;
        }
    }
}

public void SellItems(int howMany)
{
    if (amount[0] >= howMany)
    {
        amount[0] = amount[0] - howMany;
        itemText[0].text = amount[0].ToString();
    }
}
*/
}
