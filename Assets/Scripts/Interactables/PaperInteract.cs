using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PaperInteract : Interact
{
    public GameObject paper;
    public GameObject eselor;

    public float timeUntilDialogue1 = 3f;
    float timeToWait;
    

    void Start()
    {
        
    }

    public override void Interacting()
    {
        Debug.Log("Interacted");
        StartCoroutine(PressedInteract());
        paper.SetActive(true);
        timeToWait = timeUntilDialogue1;
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        StartCoroutine(StartingDialogue());
        eselor.SetActive(true);
    }
    void Update()
    {
        //Pressed E?
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            Interacting();
            isInteracting = false;
        }
    }
}
