using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextChanger : MonoBehaviour {

    public StoryState storyState;
    public StoryBank storyBank;
    public Text storyText;
	// Use this for initialization
	void Start () {
        transform.SetAsFirstSibling();
        storyState = GameObject.FindObjectOfType<StoryState>();
        storyBank = GameObject.FindObjectOfType<StoryBank>();
        storyText = gameObject.GetComponentInChildren<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        if(storyState == null)
        {
            storyState = GameObject.FindObjectOfType<StoryState>();
        }
/*
		if(storyState.newGame == true)
        {
            transform.SetAsLastSibling();
            storyText.text = storyBank.dialog1.text;
            storyText.font = storyBank.constanceLetter;

            if (Input.GetMouseButtonDown(0))
            {
                storyState.newGame = false;
                transform.SetAsFirstSibling();
                storyText.text = "";
            }

        }
        */
	}
}
