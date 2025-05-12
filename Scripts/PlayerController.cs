using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    public float speed;
    public float scale;

    public bool pressedKey;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

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

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !pressedKey)
        {
            pressedKey = true;
            anim.Play("MoveUp");
            rb.velocity = (Vector2.up * speed);
            up = true;
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !pressedKey)
        {
            pressedKey = true;
            anim.Play("MoveDown");
            rb.velocity = (Vector2.down * speed);
            down = true;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !pressedKey)
        {
            pressedKey = true;
            anim.Play("MoveLeft");
            rb.velocity = (Vector2.left * speed);
            left = true;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !pressedKey)
        {
            pressedKey = true;
            anim.Play("MoveRight");
            rb.velocity = (Vector2.right * speed);
            right = true;
        }
        if((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && pressedKey)
        {
            pressedKey = false;
            anim.Play("IdleUp");
            rb.velocity = Vector3.zero;
            up = false;
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && pressedKey)
        {
            pressedKey = false;
            anim.Play("IdleDown");
            rb.velocity = Vector3.zero;
            down = false;
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && pressedKey)
        {
            pressedKey = false;
            anim.Play("IdleLeft");
            rb.velocity = Vector3.zero;
            left = false;
        }
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && pressedKey)
        {
            pressedKey = false;
            anim.Play("IdleRight");
            rb.velocity = Vector3.zero;
            right = false;
        }
    }
}
