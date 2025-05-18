using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToEntrance : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    public GameObject cam;

    public Vector3 position;

    AudioSource _audioSource;
    private void Awake()
    {
        cam = GameObject.Find("Entrance Camera");
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
        GameManager.Instance.lastCam.gameObject.SetActive(false);
        GameManager.Instance.lastCam = cam;
        if (_audioSource == null)
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            _audioSource.volume = GameManager.Instance.sfxVolume;
            _audioSource.Play();
        }
        player.transform.position = position;
        anim.Play("IdleLeft");
        GameManager.Instance.lastRoom = "Entrance";
    }
}
