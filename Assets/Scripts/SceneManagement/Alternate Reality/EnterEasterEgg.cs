using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEasterEgg : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 bossPos;
    public Vector3 puzzlePos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Forest Item Puzzle")
        {
            Instantiate(playerPrefab, puzzlePos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
        }
        else
        {
            Instantiate(playerPrefab, bossPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
    }
}
