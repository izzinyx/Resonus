using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClassroomCutsceneTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject eselor;

    public float speed;

    Animator anim;
    Rigidbody rb;

    bool moved;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody>();
        anim.Play("IdleRight");
    }

    private void Update()
    {
        if(eselor.transform.position.x - player.transform.position.x <= 2 && !moved)
        {
            moved = true;
            anim.Play("MoveRight");
            rb.velocity = Vector3.left * speed;  
        }
        if(eselor.transform.position.x - player.transform.position.x > 2 && moved)
        {
            rb.velocity = Vector3.zero;
            anim.Play("IdleRight");
            moved = false;
        }
    }
}
