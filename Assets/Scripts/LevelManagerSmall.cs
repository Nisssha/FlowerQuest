using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerSmall : MonoBehaviour {
    private SaveLoadUtility slu;

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadFlowerCrush()
    {
        if (slu == null)
        {
            slu = GameObject.FindObjectOfType<SaveLoadUtility>();
        }
        slu.SaveGame(slu.quickSaveName);
        SceneManager.LoadScene("FlowerCrush");
    }
}
