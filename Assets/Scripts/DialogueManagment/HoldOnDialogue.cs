using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldOnDialogue : MonoBehaviour {

    public GameObject OnHold;
    public StoryState storyState;
    public DialogueManager dialogueManager;

    private void Update()
    {
        transform.SetAsLastSibling();

        if (storyState == null)
        {
            storyState = GameObject.FindObjectOfType<StoryState>();
        }
        if (dialogueManager == null)
        {
            dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        }
    }

    public void WaitForFlowers()
    {
        storyState.dialogueOn = false;

        GameObject button = (GameObject)Instantiate(OnHold);
        Button b = button.GetComponent<Button>();
        ResumeDialogue resume = button.GetComponent<ResumeDialogue>();
        resume.numberLine = dialogueManager.lineNum;

        b.transform.SetParent(GameObject.FindGameObjectWithTag("Garden").transform);
        b.transform.localPosition = new Vector3(878, 363);
        b.transform.localScale = new Vector3(1, 1, 1);
    }

}
