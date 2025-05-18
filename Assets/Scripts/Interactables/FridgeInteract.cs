using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeInteract : Interact
{
    public bool ate;
    public bool opened;

    public GameObject openedFridgeWObjects;
    public GameObject openedFridgeNoObjects;
    public GameObject openFridgeScript;
    public GameObject dialogueController2;
    public GameObject yesChoice;

    public override void Interacting()
    {
        Debug.Log("Interacting");
        StartCoroutine(PressedInteract());

        if (hasDialogue && !opened)
        {
            StartCoroutine(StartingDialogue());
        }

        if(opened && !ate)
        {
            ate = true;
            StartCoroutine(StartingDialogue2());
        }

        else if(opened)
        {
            opened = false;
            openFridgeScript.SetActive(false);
            yesChoice.SetActive(false);
        }
    }

    public IEnumerator StartingDialogue2()
    {
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        dialogueController2.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            Interacting();
            isInteracting = false;
        }

        if (opened && !ate)
        {
            openedFridgeWObjects.SetActive(true);
        }
        if(opened && ate)
        {
            openedFridgeNoObjects.SetActive(true);
        }
        if (!opened)
        {
            openedFridgeNoObjects.SetActive(false);
            openedFridgeWObjects.SetActive(false);
        }
    }
}
