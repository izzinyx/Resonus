using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDining : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    public GameObject cam;

    public Vector3 kitchenPos;
    public Vector3 entrancePos;
    public Vector3 stairsPos;

    AudioSource _audioSource;

    private void Awake()
    {
        cam = GameObject.Find("Dining Camera");
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
        if (GameManager.Instance.lastScene == "Kitchen")
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
            player.transform.position = kitchenPos;
            anim.Play("IdleLeft");
        }
        if (GameManager.Instance.lastScene == "Hallway")
        {

            player.transform.position = stairsPos;
            anim.Play("IdleDown");
        }
        if (GameManager.Instance.lastScene == "Entrance")
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.volume = GameManager.Instance.sfxVolume;
                _audioSource.Play();
            }
            player.transform.position = entrancePos;
            anim.Play("IdleRight");
        }
        GameManager.Instance.lastRoom = "Dining";
    }
}
