using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDining : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 kitchenPos;
    public Vector3 entrancePos;
    public Vector3 stairsPos;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Kitchen Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, kitchenPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
        }
        if (GameManager.Instance.lastScene == "Hallway Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, stairsPos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleDown");
        }
        if (GameManager.Instance.lastScene == "Entrance Start")
        {
            _audioSource.Play();
            Instantiate(playerPrefab, entrancePos, Quaternion.identity);
            GameObject player = GameObject.Find("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
    }
}
