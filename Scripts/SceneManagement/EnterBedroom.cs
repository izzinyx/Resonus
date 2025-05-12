using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBedroom : MonoBehaviour
{
    public GameObject playerPrefab; 

    public Vector3 startPos;
    public Vector3 enterPos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if(GameManager.Instance.lastScene == "Main Menu")
        {
            Instantiate(playerPrefab, startPos, Quaternion.identity);
        }
        else
        {
            _audioSource.Play();
            Instantiate(playerPrefab, enterPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
    }

}
