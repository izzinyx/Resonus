using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Slider volumeSlider;
    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
    }

    public void Update()
    {
        if (volumeSlider.gameObject.CompareTag("Music"))
        {
            GameManager.Instance.musicVolume = volumeSlider.value;
        }
        if (volumeSlider.gameObject.CompareTag("SFX"))
        {
            GameManager.Instance.sfxVolume = volumeSlider.value;
        }
    }
}
