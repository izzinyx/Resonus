using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivate : MonoBehaviour
{
    public GameObject panel;
    private void OnEnable()
    {
        panel.SetActive(true);
    }
}
