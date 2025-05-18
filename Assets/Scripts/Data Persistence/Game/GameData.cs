using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int routeTaken;
    public string lastScene;
    public float posX, posY, posZ;

    public GameData()
    {
        this.routeTaken = 0;
        this.lastScene = "Bedroom Start";
        this.posX = 0;
        this.posY = 0;
        this.posZ = -1.5f;
    }
}
