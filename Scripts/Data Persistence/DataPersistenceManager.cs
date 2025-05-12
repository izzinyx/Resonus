using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple Data Persistence Manager in the scene");

        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //Load saved data from json file


        //No data to load?
        if(this.gameData == null)
        {
            Debug.Log("No data found. Data set to default");
            NewGame();
        }

        //Load data to scripts
    }

    public void SaveGame()
    {
        //Update script data

        //Save data in json file
    }
}
