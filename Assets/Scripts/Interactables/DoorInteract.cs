using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interact
{
    public GameObject player;
    public GameObject goToNextScene;
    public AudioClip doorInteract;
    PlayerController playerController;
    Animator anim;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public override void Interacting()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<PlayerController>();
            anim = player.GetComponent<Animator>();
        }
        base.Interacting();
        audioSource.clip = doorInteract;
        audioSource.volume = GameManager.Instance.sfxVolume;
        audioSource.Play(); 
        if (goToNextScene != null)
        {
            goToNextScene.SetActive(true);
        }
        if (playerController != null)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            playerController.enabled = false;
        }
        if (anim != null)
        {
            if (playerController.up)
            {
                anim.Play("IdleUp");
            }
            if (playerController.down)
            {
                anim.Play("IdleDown");
            }
            if (playerController.left)
            {
                anim.Play("IdleLeft");
            }
            if (playerController.right)
            {
                anim.Play("IdleRight");
            }
        }
    }
    public override void TriggerInteract()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<PlayerController>();
            anim = player.GetComponent<Animator>();
        }
        base.TriggerInteract();
        if (hasDialogue)
        {
            if (playerController != null)
            {
                Rigidbody rb = player.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                playerController.enabled = false;
            }
            if (anim != null)
            {
                if (playerController.up)
                {
                    anim.Play("IdleUp");
                }
                if (playerController.down)
                {
                    anim.Play("IdleDown");
                }
                if (playerController.left)
                {
                    anim.Play("IdleLeft");
                }
                if (playerController.right)
                {
                    anim.Play("IdleRight");
                }
            }
            StartCoroutine(StartingDialogue());

        }
        else
        {
            if (audioSource.clip != null)
            {
                audioSource.clip = doorInteract;
                audioSource.volume = GameManager.Instance.sfxVolume;
                audioSource.Play();
            }
            if(goToNextScene != null)
            {
                goToNextScene.SetActive(true);
            }
            if (playerController != null)
            {
                Rigidbody rb = player.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                playerController.enabled = false;
            }
            if (anim != null)
            {
                if (playerController.up)
                {
                    anim.Play("IdleUp");
                }
                if (playerController.down)
                {
                    anim.Play("IdleDown");
                }
                if (playerController.left)
                {
                    anim.Play("IdleLeft");
                }
                if (playerController.right)
                {
                    anim.Play("IdleRight");
                }
            }
        }
    }
}
