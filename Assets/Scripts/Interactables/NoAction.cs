using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class NoAction : MonoBehaviour
{
    GameObject player;
    PlayerController controller;

    bool isInAction;
    public Choices choices;
    public TextMeshProUGUI choice1;
    public TextMeshProUGUI choice2;
    public GameObject ActionTrigger;

    void OnEnable()
    {
        isInAction = true;
        StartCoroutine(WaitForAnimation());
        ActionTrigger.SetActive(true);
        PlayableDirector timeline = ActionTrigger.GetComponent<PlayableDirector>();
        timeline.Play();
    }

    private void OnDisable()
    {
        isInAction = false;
        PlayableDirector timeline = ActionTrigger.GetComponent<PlayableDirector>();
        timeline.initialTime = 0;
        choice1.enabled = true;
        choice2.enabled = true;
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        choices.choiceSelected.SetActive(false);
        choices.gameObject.SetActive(false);
        PlayableDirector choicesTimeline = choices.gameObject.GetComponent<PlayableDirector>();
        choicesTimeline.initialTime = 0;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            controller = player.GetComponent<PlayerController>();
        }
        if (!isInAction)
        {
            controller.enabled = true;
        }
    }
}
