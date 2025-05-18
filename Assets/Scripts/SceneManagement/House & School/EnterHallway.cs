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

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.lastScene == "Bedroom Start")
        {
            Instantiate(playerPrefab, bedroomPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleLeft");
            if(_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }
        if (GameManager.Instance.lastScene == "Bathroom Start")
        {
            Instantiate(playerPrefab, bathroomPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleDown");
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }
        if (GameManager.Instance.lastScene == "Parent Start")
        {
            Instantiate(playerPrefab, parentPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleDown");
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }
        if (GameManager.Instance.lastScene == "Dining Start")
        {
            Instantiate(playerPrefab, stairsPos, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator anim = player.GetComponent<Animator>();
            anim.Play("IdleUp");
        }
    }

}
