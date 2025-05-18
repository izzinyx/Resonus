using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public GameObject interactIcon;
    public GameObject interactedIcon;

    public bool isInteracting;
    public bool isTriggerInteracting;

    public bool hasDialogue;
    public GameObject dialogueController;
    public GameObject dialoguePanel;

    public AudioSource audioSource;
    public AudioClip obtainedItem;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        //Pressed E?
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            Interacting();
            isInteracting = false;
        }

        //Entered into a triggered object?
        if (isTriggerInteracting)
        {
            TriggerInteract();
            isTriggerInteracting = false;
        }
    }

    //Animation for pressing the button
    public IEnumerator PressedInteract()
    {
        interactedIcon.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        interactedIcon.SetActive(false);
        interactIcon.SetActive(false);
    }


    public virtual void Interacting()
    {
        //Obtainable item?
        if (obtainedItem != null)
        {
            audioSource.volume = GameManager.Instance.sfxVolume;
            audioSource.clip = obtainedItem;
            audioSource.Play();
        }

        StartCoroutine(PressedInteract());
        //Needs to be fliped?
        if (gameObject.CompareTag("ToFlip"))
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.flipX = true;
        }
        //Dialogue?
        if (hasDialogue)
        {
            StartCoroutine(StartingDialogue());
        }
    }

    //Wait for Dialogue initialization
    public IEnumerator StartingDialogue()
    {
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        dialogueController.SetActive(true);
    }


    public virtual void TriggerInteract()
    {
        
    }

    //In range of interactable object?
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("TriggerInteractable"))
        {
            isTriggerInteracting = true;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            isInteracting = true;
            interactIcon.SetActive(true);
        }
    }

    //Outside the range of interactable object?
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("TriggerInteractable"))
        {
            isTriggerInteracting = false;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            isInteracting = false;
            interactIcon.SetActive(false);
        }
    }
}
