using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHallway : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    public GameObject cam;

    public Vector3 bedroomPos;
    public Vector3 bathroomPos;
    public Vector3 parentPos;
    public Vector3 stairsPos;

    AudioSource _audioSource;

    private void Awake()
    {
        cam = GameObject.Find("Hallway Camera");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        cam.SetActive(true);
        GameManager.Instance.lastCam.gameObject.SetActive(false);
        GameManager.Instance.lastCam = cam;
        if (GameManager.Instance.lastRoom == "Bedroom")
        {
            player.transform.position = bedroomPos;
            anim.Play("IdleLeft");
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }
        if (GameManager.Instance.lastScene == "Bathroom")
        {
            player.transform.position = bathroomPos;
            anim.Play("IdleDown");
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }
        if (GameManager.Instance.lastScene == "Parent")
        {
            player.transform.position = parentPos;
            anim.Play("IdleDown");
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }
        if (GameManager.Instance.lastScene == "Dining")
        {
            player.transform.position = stairsPos;
            anim.Play("IdleUp");
        }
        GameManager.Instance.lastRoom = "Hallway";
    }

}
