using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue, characterName;
    public int lineNum;
    int pose;
    string position;
    string[] options;
    public bool playerTalking;
    public List<Button> buttons = new List<Button>();

    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox;
    public GameObject sellBox;
    public GameObject sellMultiBox;

    public GameObject storyCanvas;
    public DialogueParser dialogueParser;
    public StoryState storyState;
    private Inventory inventory;
    private ChangeCameraGarden changeCamera;
    public SaveLoadUtility slu;

    public int dialogLinesNumber;

    void Start()
    {
        dialogue = "";
        characterName = "";
        pose = 0;
        position = "L";
        playerTalking = false;
        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        lineNum = 0;

        storyCanvas = GameObject.FindGameObjectWithTag("Garden");
        dialogueParser = GameObject.FindObjectOfType<DialogueParser>();
        storyState = GameObject.FindObjectOfType<StoryState>();
        changeCamera = GameObject.FindObjectOfType<ChangeCameraGarden>();
        if (!storyState.dialogueOn)
        {
            transform.SetAsFirstSibling();
        }
    }

    public void Resume()
    {
        LoadDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (!storyState.dialogueOn)
        {
            transform.SetAsFirstSibling();
        }
        if (parser == null)
        {
            parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        }
        if (storyState == null)
        {
            storyState = GameObject.FindObjectOfType<StoryState>();
        }
        if (inventory == null)
        {
            inventory = GameObject.FindObjectOfType<Inventory>();
        }
        if (slu == null)
        {
            slu = GameObject.FindObjectOfType<SaveLoadUtility>();
        }
        if (changeCamera == null)
        {
            changeCamera = GameObject.FindObjectOfType<ChangeCameraGarden>();
        }


        if (storyState.dialogueOn && changeCamera.gardenActive)
        {
            if (dialogLinesNumber == 0)
            {
                slu.SaveGame(slu.quickSaveName);
                LoadDialogue();
                dialogLinesNumber = dialogueParser.GetLineNumber();
            }
           // transform.SetAsLastSibling();
            if(lineNum == 0)
            {
                //A TEST FOR INVENTORY
                /*
                string[] flowersSell = new string[] { "Dandelion", "Daisy" };
                int[] flowersAmount = new int[] { 2, 1 };
                bool canSell = inventory.CheckAvailabilityMultiple(flowersSell, flowersAmount);

                Debug.Log(canSell);
                if(canSell)
                    inventory.RemoveMultipleItems(flowersSell, flowersAmount);

                */
                //END OF TEST FOR INVENTORY

                ShowDialogue();
            }

            else if (Input.GetMouseButtonDown(0) && playerTalking == false)
            {
                ShowDialogue();
            }
            
        }
    }
    public void ShowDialogue()
    {
        transform.SetAsLastSibling();
        ResetImages();
        if (buttons != null)
        {
            ClearButtons();
        }

        ParseLine();
        dialogueBox.text = dialogue;
        nameBox.text = characterName;
        
    }

    void UpdateUI()
    {
        dialogueBox.text = dialogue;
        nameBox.text = characterName;
        
    }

    public void ClearButtons()
    {
        foreach (Button b in buttons)
        {
            Destroy(b.gameObject);
        }
        buttons.Clear();
        
    }

    void ParseLine()
    {
        if(parser.GetName(lineNum) == "End")
        {
            ResetImages();
            EndDialogue();
            return;
        }

        if (parser.GetName(lineNum) != "Player" && parser.GetName(lineNum) != "Sell" && parser.GetName(lineNum) != "SellMultiple")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            if (parser.GetName(lineNum) != "Kitty")
            {
                pose = parser.GetPose(lineNum);
                position = parser.GetPosition(lineNum);
                DisplayImages();
            }
            lineNum++;
        }

        else
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            pose = 0;
            position = "";
            options = parser.GetOptions(lineNum);
            CreateButtons();
        }
    }

    void CreateButtons()
    {
        //Debug.Log(parser.GetName(lineNum));
        for (int i = 0; i < options.Length; i++)
        {
            if (parser.GetName(lineNum) == "Player")
            {
                GameObject button = (GameObject)Instantiate(choiceBox);
                Button b = button.GetComponent<Button>();
                ChoiceButton cb = button.GetComponent<ChoiceButton>();
                cb.SetText(options[i].Split(':')[0]);
                cb.option = options[i].Split(':')[1];
                cb.boolToSetTrue = options[i].Split(':')[2];
                cb.sympathyPerson = options[i].Split(':')[3];
                cb.sympathyValue = int.Parse(options[i].Split(':')[4]);
                cb.box = this;
                b.transform.SetParent(this.transform);
                b.transform.localPosition = new Vector3(0, -25 + (i * 100));
                b.transform.localScale = new Vector3(1, 1, 1);
                buttons.Add(b);
            }else if(parser.GetName(lineNum) == "Sell")
            {
                //Sell; Sell a rose: rose: none: 0; Wait: none: none: 0
                GameObject button = (GameObject)Instantiate(sellBox);
                Button b = button.GetComponent<Button>();
                SellButton cb = button.GetComponent<SellButton>();
                cb.SetText(options[i].Split(':')[0]);
                cb.flowerName = options[i].Split(':')[1];
                cb.sympathyPerson = options[i].Split(':')[2];
                cb.sympathyValue = int.Parse(options[i].Split(':')[3]);
                cb.box = this;
                b.transform.SetParent(this.transform);                           //HERE ARE BOX POSITIONS, YOU CAN DO IT LATER
                b.transform.localPosition = new Vector3(0, -25 + (i * 100));
                b.transform.localScale = new Vector3(1, 1, 1);
                buttons.Add(b);
                cb.Check();
            }
            else if (parser.GetName(lineNum) == "SellMultiple")
            {
                //               0                               1          2              3              4         5
                //SellMultiple;Sell 2 Daisies and 1 dandelion:    2   :    2.1   :  Daisy.Dandelion  :  none   :    0             ;Wait:0:0:none:none:0
                GameObject button = (GameObject)Instantiate(sellMultiBox);
                Button b = button.GetComponent<Button>();
                SellMultiButton cb = button.GetComponent<SellMultiButton>();
                cb.SetText(options[i].Split(':')[0]);
                cb.numberOfTypes = int.Parse(options[i].Split(':')[1]);
                List<string> flowersToPass = new List<string>();
                List<int> amountsToPass = new List<int>();

                for(int j = 0; j < cb.numberOfTypes; j++)
                {
                    //Debug.Log("Loop j: " + j);
                    flowersToPass.Add(options[i].Split(':')[3].Split('.')[j]);
                    int amount = int.Parse(options[i].Split(':')[2].Split('.')[j]);
                    amountsToPass.Add(amount);
                    //Debug.Log(flowersToPass.Count); 
                }

                cb.flowerName = flowersToPass.ToArray();
                cb.flowerAmount = amountsToPass.ToArray();
                cb.sympathyPerson = options[i].Split(':')[4];
                cb.sympathyValue = int.Parse(options[i].Split(':')[5]);
                cb.box = this;
                b.transform.SetParent(this.transform);                           //HERE ARE BOX POSITIONS, YOU CAN DO IT LATER
                b.transform.localPosition = new Vector3(0, -25 + (i * 100));
                b.transform.localScale = new Vector3(1, 1, 1);
                buttons.Add(b);
                cb.Check();
            }
        }
    }

    void ResetImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.FindGameObjectWithTag("Character");
            Destroy(character);
        }
    }

    void DisplayImages()
    {
        if (characterName != "")
        {
         string path = "Prefabs/Characters/" + characterName;
            GameObject character = Instantiate(Resources.Load(path)) as GameObject;
            if (storyCanvas == null)
            {
                storyCanvas = GameObject.FindGameObjectWithTag("Garden");
            }
            character.transform.SetParent(storyCanvas.transform);

            SetSpritePositions(character);

            Image currSprite = character.GetComponent<Image>();
            currSprite.sprite = character.GetComponent<Character>().characterPoses[pose];
        }
    }


    void SetSpritePositions(GameObject spriteObj)
    {

        spriteObj.transform.localPosition = new Vector3(-750, 0);
        spriteObj.transform.localScale = new Vector3(1, 1, 1);

    }

    void EndDialogue()
    {
        Debug.Log("End of the dialogue");
        dialogLinesNumber = 0;
        lineNum = 0;
        transform.SetAsFirstSibling();
        storyState.encounterOn = false;
        storyState.dialogueOn = false;
        

        if (storyState.aiden1enc)
        {
            storyState.aiden1done = true;
            storyState.aiden1enc = false;   
        }

        if (storyState.priest1enc)
        {
            storyState.priest1done = true;
            storyState.priest1enc = false;
        }

        if (storyState.aiden2enc)
        {
            storyState.aiden2done = true;
            storyState.aiden2enc = false;
        }

        slu.SaveGame(slu.quickSaveName);
    }

    private void LoadDialogue()
    {
        if (storyState.aiden1enc)
        {
            string fileName = "Assets/Resources/Text/Dialogue/Dialogue";
            dialogueParser.LoadDialogue(fileName + "0.txt");
        }
        else if (storyState.priest1enc)
        {
            string fileName = "Assets/Resources/Text/Dialogue/Dialogue";
            dialogueParser.LoadDialogue(fileName + "1.txt");
        }
        else if (storyState.aiden2enc) // && storyState.sympAiden >= 0)
        {
            string fileName = "Assets/Resources/Text/Dialogue/Dialogue";
            dialogueParser.LoadDialogue(fileName + "2.txt");
        }
        /*
        else if(storyState.aiden2enc && storyState.sympAiden < 0)
        {
            string fileName = "Assets/Resources/Text/Dialogue/Dialogue";
            dialogueParser.LoadDialogue(fileName + "2Letter.txt");
        }
        */
    }


}
