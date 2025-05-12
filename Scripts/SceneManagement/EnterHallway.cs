using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHallway : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 bedroomPos;
    public Vector3 bathroomPos;
    public Vector3 parentPos;
    public Vector3 stairsPos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Bedroom Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, bedroomPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
        }
        if (GameManager.Instance.lastScene == "Bathroom Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, bathroomPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleDown");
        }
        if (GameManager.Instance.lastScene == "Parent Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, parentPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleDown");
        }
        if (GameManager.Instance.lastScene == "Dining Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, stairsPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleUp");
        }
    }

}
