using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    CinemachineVirtualCamera cam;

    public float speed;
    public float scale;

    public bool pressedW;
    public bool pressedA;
    public bool pressedS;
    public bool pressedD;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GameObject vcam = GameObject.Find("Virtual Camera");
        if(vcam != null)
        {
            cam = vcam.GetComponent<CinemachineVirtualCamera>();
            cam.Follow = gameObject.transform;
        }

        //Change the scale on instance
        if (transform.localScale.x != scale)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }

        //Top-Down Controls require full control of screen, so there will be no gravity involved
        Physics.gravity *= 0f;
    }

    void Update()
    {
        //Check for movement keys & for the moment the player stops

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !pressedW && !pressedA && !pressedD && !pressedS)
        {
            pressedW = true;
            anim.Play("MoveUp");
            rb.velocity = (Vector2.up * speed);
            up = true;
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !pressedW && !pressedA && !pressedD && !pressedS)
        {
            pressedS = true;
            anim.Play("MoveDown");
            rb.velocity = (Vector2.down * speed);
            down = true;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !pressedW && !pressedA && !pressedD && !pressedS)
        {
            pressedA = true;
            anim.Play("MoveLeft");
            rb.velocity = (Vector2.left * speed);
            left = true;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !pressedW && !pressedA && !pressedD && !pressedS)
        {
            pressedD = true;
            anim.Play("MoveRight");
            rb.velocity = (Vector2.right * speed);
            right = true;
        }
        if((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && pressedW)
        {
            pressedW = false;
            anim.Play("IdleUp");
            rb.velocity = Vector3.zero;
            up = false;
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && pressedS)
        {
            pressedS = false;
            anim.Play("IdleDown");
            rb.velocity = Vector3.zero;
            down = false;
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && pressedA)
        {
            pressedA = false;
            anim.Play("IdleLeft");
            rb.velocity = Vector3.zero;
            left = false;
        }
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && pressedD)
        {
            pressedD = false;
            anim.Play("IdleRight");
            rb.velocity = Vector3.zero;
            right = false;
        }
    }
}
