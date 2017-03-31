using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public SaveLoadUtility slu;
    public List<SaveGame> saveGames;
    
    void Start()
    {
        if (slu == null)
        {
            slu = GetComponent<SaveLoadUtility>();
            if (slu == null)
            {
                Debug.Log("[SaveLoadMenu] Start(): Warning! SaveLoadUtility not assigned!");
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGame()
    {
        LoadOrNotToLoad.loadGame = true;
        SceneManager.LoadScene("Game");
    }

    IEnumerator Waiting()
    {
        //slu.LoadGame(slu.quickSaveName);
        yield return null;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }


    public void Escape()
    {
        Application.Quit();
    }
}
