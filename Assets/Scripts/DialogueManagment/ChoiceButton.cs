using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{

    public string option;
    public DialogueManager box;
    public string boolToSetTrue;
    public string sympathyPerson;
    public int sympathyValue;


    private StoryState storyState;

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
    }

    public void SetOption(string newOption)
    {
        this.option = newOption;
    }

    public void ParseOption()
    {
        string command = option.Split(',')[0];
        string commandModifier = option.Split(',')[1];
        box.playerTalking = false;

        if (storyState == null)
        {
            storyState = GameObject.FindObjectOfType<StoryState>();
        }

        //cast string name to property name in StoryState script and set that propert to true
        if (boolToSetTrue != "none")
        {
            System.Reflection.FieldInfo propName = storyState.GetType().GetField(boolToSetTrue);
            propName.SetValue(storyState, true);
        }

        //change sympathy value
        storyState.SetSympathy(sympathyPerson, sympathyValue);

        if (command == "line")
        {
            box.lineNum = int.Parse(commandModifier);
            box.ShowDialogue();
        }
        else if (command == "scene")
        {
            SceneManager.LoadScene("Scene" + commandModifier);
        }
    }
}
