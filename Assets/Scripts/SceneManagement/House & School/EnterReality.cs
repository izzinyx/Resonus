using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterReality : MonoBehaviour
{
    public GameObject playerPrefab;
    private void OnEnable()
    {
        Instantiate(playerPrefab, GameManager.Instance.playerPos, Quaternion.identity);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator anim = player.GetComponent<Animator>();
        anim.Play("IdleRight");
    }
}
