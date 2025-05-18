using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBedroom : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    public GameObject cam;

    public Vector3 enterPos;


    AudioSource _audioSource;

    private void Awake()
    {
        cam = GameObject.Find("Bedroom Camera");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        cam.SetActive(true);
        if(GameManager.Instance.lastRoom != null)
        {
            player.transform.position = enterPos;
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
        }

        anim.Play("IdleRight");
        if(GameManager.Instance.lastCam != null)
        {
            GameManager.Instance.lastCam.gameObject.SetActive(false);
        }
        GameManager.Instance.lastCam = cam;
        GameManager.Instance.lastRoom = "Bedroom";
    }
}
