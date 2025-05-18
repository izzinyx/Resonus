using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForestShop : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 tutorialPos;
    public Vector3 puzzlePos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Forest Battle Tutorial")
        {
            Instantiate(playerPrefab, tutorialPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
        else
        {
            Instantiate(playerPrefab, puzzlePos, Quaternion.identity);
        }
    }
}
