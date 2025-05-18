using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDiningChoice : MonoBehaviour
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
        if (GameManager.Instance.lastScene == "Kitchen Choice")
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
            Instantiate(playerPrefab, kitchenPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
        }
        if (GameManager.Instance.lastScene == "Hallway Choice")
        {

            Instantiate(playerPrefab, stairsPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleDown");
        }
        if (GameManager.Instance.lastScene == "Entrance Choice")
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
            Instantiate(playerPrefab, entrancePos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleRight");
        }
    }
}
