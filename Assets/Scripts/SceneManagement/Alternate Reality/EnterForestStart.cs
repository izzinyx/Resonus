using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForestStart : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 startPos;
    public Vector3 tutorialPos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Dining Choice")
        {
            Instantiate(playerPrefab, startPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleUp");
        }
        else
        {
            Instantiate(playerPrefab, tutorialPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
        }
    }
}
