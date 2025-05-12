using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEntrance : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 position;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _audioSource.Play();
        Instantiate(playerPrefab, position, Quaternion.identity);
        GameObject player = GameObject.Find("Player");
        Animator anim = player.GetComponent<Animator>();
        anim.Play("IdleLeft");
    }
}
