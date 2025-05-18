using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTutorial : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 shopsPos;
    public Vector3 startPos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Forest Start")
        {
            Instantiate(playerPrefab, startPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
        else
        {
            Instantiate(playerPrefab, shopsPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
        }
    }
}
