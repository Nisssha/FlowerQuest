using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public bool win = false;
    int goal;
    int overGoal = 0;
    int time = 60;
    Text timeText;
    GameObject[] panelChildren;
    GameObject flowersArray;
    ShapesManager shapesManager;

    public Text goalText;

	void Start ()
    {
        flowersArray = GameObject.FindObjectOfType<ShapesManager>().gameObject;
        shapesManager = flowersArray.GetComponent<ShapesManager>();

        panelChildren = GameObject.FindGameObjectsWithTag("ScorePanel");

        foreach(GameObject child in panelChildren)
        {
            child.SetActive(false);
        }

        timeText = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
        timeText.text = time.ToString();

        goal = Random.Range(8000, 15000);

        goalText.text = "Goal: " +goal.ToString();

        InvokeRepeating("UpdateTime", 0f, 1f);
    }
	
	void Update ()
    {
        if (shapesManager.score >= goal)
        {
            Debug.Log("Win: " + win);
            win = true;
            overGoal = shapesManager.score - goal;
        }	
	}

    private void UpdateTime()
    {
        if (time > 0)
        {
            time -= 1;
            timeText.text = time.ToString();
        }else
        {
            foreach (GameObject child in panelChildren)
            {
                child.SetActive(true);
            }
            TransportResultScript.flowerQuest = true;
            TransportResultScript.win = win;
            TransportResultScript.over = overGoal;
            Destroy(flowersArray);
        }
        
    }
}
