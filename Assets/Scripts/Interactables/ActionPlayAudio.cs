using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void OnEnable()
    {
        audioSource.volume = GameManager.Instance.sfxVolume;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
