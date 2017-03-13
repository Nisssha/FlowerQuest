/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

    //public static List<Game> savedGames = new List<Game>();
    public static Game saveGame;
    // public static FlowerGrowing[] save;

    public static void Save(){

       saveGame = new Game();
       Debug.Log(saveGame);
        // Debug.Log(Game.buu);
        //  Debug.Log(current.sav)
        //Debug.Log(Game.Game());

       // save = GameObject.FindObjectsOfType<FlowerGrowing>();

       // savedGames.Add(Game.current);
        //Debug.Log(savedGames[0]);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
       // bf.Serialize(file, SaveLoad.savedGames);
        bf.Serialize(file, SaveLoad.saveGame);
        Debug.Log(file);
        file.Close();
	}

	public static void Load() {
		if (File.Exists(Application.persistentDataPath + "/savedGames.gd")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.saveGame = (Game)bf.Deserialize(file);
			file.Close();

          //  FlowerGrowing[] flowers = saveGame.save;
           // foreach()

			}
	}
}

*/