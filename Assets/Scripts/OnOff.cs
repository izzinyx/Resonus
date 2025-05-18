using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public List<GameObject> on;
    public List<GameObject> off;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for(int i = 0; i < on.Count; i++)
        {
            on[i].SetActive(true);
        }
        for (int i = 0; i < off.Count; i++)
        {
            off[i].SetActive(false);
        }
    }
}
