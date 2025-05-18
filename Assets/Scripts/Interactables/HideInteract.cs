using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInteract : Interact
{
    public GameObject openedObject;
    public GameObject player;

    public override void Interacting()
    {
        if (!GameManager.Instance.hiding)
        {
            StartCoroutine(PressedInteract());
            openedObject.SetActive(true);
            if(player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            player.SetActive(false);
            GameManager.Instance.hiding = true;
        }
    }

    private void Update()
    {
        if(GameManager.Instance.hiding && Input.GetKeyDown(KeyCode.E))
        {
            openedObject.SetActive(false);
            player.SetActive(true);
            GameManager.Instance.hiding = false;
        }
    }
}
