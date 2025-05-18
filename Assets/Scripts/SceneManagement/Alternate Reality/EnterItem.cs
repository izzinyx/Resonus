using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterItem : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 shopsPos;
    public Vector3 easterPos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Forest Shops")
        {
            Instantiate(playerPrefab, shopsPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleUp");
        }
        else
        {
            Instantiate(playerPrefab, easterPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
    }
}
