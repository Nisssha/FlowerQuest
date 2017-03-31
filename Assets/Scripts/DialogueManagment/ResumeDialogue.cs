using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeDialogue : MonoBehaviour {

    private StoryState storyState;
    private DialogueManager box;
    public int numberLine;

    public void Resume()
    {
        if (storyState == null)
        {
            storyState = GameObject.FindObjectOfType<StoryState>();
        }
        if (box == null)
        {
            box = GameObject.FindObjectOfType<DialogueManager>();
        }
        box.Resume();
        box.lineNum = numberLine;
        box.ShowDialogue();
        storyState.dialogueOn = true;
        Destroy(this.gameObject);
    }
}
