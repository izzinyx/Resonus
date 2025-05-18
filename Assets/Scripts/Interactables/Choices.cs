using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Choices : MonoBehaviour
{
    GameObject player;
    PlayerController controller;

    public GameObject action1;
    public GameObject action2;
    public GameObject selectChoice1;
    public GameObject selectChoice2;

    public GameObject choiceSelected;
    public TextMeshProUGUI dialogueText;

    PlayableDirector timeline;
    PlayableDirector choiceSelectedTimeline;

    bool IsFocused(GameObject selectChoice)
    {
        if (selectChoice.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        choiceSelectedTimeline = choiceSelected.GetComponent<PlayableDirector>();
        selectChoice1.SetActive(true);
        choiceSelected.SetActive(false);
        StartCoroutine(WaitForAnimation());
    }

    private void OnEnable()
    {
        if (timeline == null)
        {
            timeline = GetComponent<PlayableDirector>();
        }
        timeline.initialTime = 0;
        timeline.Play();
        selectChoice1.SetActive(true);
        selectChoice2.SetActive(false);
        choiceSelected.SetActive(false);
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            controller = player.GetComponent<PlayerController>();
            controller.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (IsFocused(selectChoice1))
            {
                selectChoice1.SetActive(false);
                selectChoice2.SetActive(true);
            }
            else
            {
                selectChoice2.SetActive(false);
                selectChoice1.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (IsFocused(selectChoice1))
            {
                selectChoice1.SetActive(false);
                selectChoice2.SetActive(true);
            }
            else
            {
                selectChoice2.SetActive(false);
                selectChoice1.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Enter");
            if (IsFocused(selectChoice1))
            {
                action1.SetActive(true);
                selectChoice1.SetActive(false);
            }
            else
            {
                action2.SetActive(true);
                selectChoice2.SetActive(false);
            }
            choiceSelected.SetActive(true);
            dialogueText.text = string.Empty;
            choiceSelectedTimeline.initialTime = 0;
            choiceSelectedTimeline.Play();
            gameObject.SetActive(false);
        }
    }
}
