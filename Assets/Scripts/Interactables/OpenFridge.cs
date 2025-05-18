using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridge : MonoBehaviour
{
    public FridgeInteract fridgeInteract;


    private void OnEnable()
    {
        fridgeInteract.opened = true;
    }
}
