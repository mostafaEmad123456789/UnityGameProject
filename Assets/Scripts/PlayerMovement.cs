﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator anim;

//    Transform player;

    //public Transform gun;

    //public Transform camera;

    //Vector3 space = new Vector3(0, 2f, -0.4f);

    //Vector3 gunSpace = new Vector3(-0.2f, 0, -0.2f);

    void Start()
    {
        anim = GetComponent<Animator>();
      //  player = GetComponent<Transform>();
    }

    public void MoveForward()
    {
        anim.SetBool("IsWalkingForward", true);
        anim.SetBool("IsWalkingBackward", false);
        anim.SetBool("IsWalkingRight", false);
        anim.SetBool("IsWalkingLeft", false);

        anim.SetBool("IsIdle", false);
        //gun.position = player.position + gun.position;
        transform.Translate(0, 0, 0.1f);
    }

    public void MoveBackward()
    {
        anim.SetBool("IsWalkingForward", false);
        anim.SetBool("IsWalkingBackward", true);
        anim.SetBool("IsWalkingRight", false);
        anim.SetBool("IsWalkingLeft", false);

        anim.SetBool("IsIdle", false);
        //gun.position = player.position + gun.position;
        transform.Translate(0, 0, -0.1f);
    }

    public void MoveRight()
    {
        anim.SetBool("IsWalkingForward", false);
        anim.SetBool("IsWalkingBackward", false);
        anim.SetBool("IsWalkingRight", true);
        anim.SetBool("IsWalkingLeft", false);

        anim.SetBool("IsIdle", false);
        // gun.position = player.position + gun.position;
        transform.Translate(0.1f, 0, 0);
    }

    public void MoveLeft()
    {
        anim.SetBool("IsWalkingForward", false);
        anim.SetBool("IsWalkingBackward", false);
        anim.SetBool("IsWalkingRight", false);
        anim.SetBool("IsWalkingLeft", true);

        anim.SetBool("IsIdle", false);
        // gun.position = player.position + gun.position;
        transform.Translate(-0.1f, 0, 0);
    }

    public void Jump()
    {
        anim.SetBool("IsWalkingForward", false);
        anim.SetBool("IsWalkingBackward", false);
        anim.SetBool("IsWalkingRight", false);
        anim.SetBool("IsWalkingLeft", false);
        anim.SetTrigger("IsJumping");
        anim.SetBool("IsIdle", false);
        // gun.position = player.position + gun.position;
        //transform.Translate(0, 0.5f, 0);
    }

    public void Idle()
    {
        anim.SetBool("IsWalkingForward", false);
        anim.SetBool("IsWalkingBackward", false);
        anim.SetBool("IsWalkingRight", false);
        anim.SetBool("IsWalkingLeft", false);
        // anim.SetBool("IsJumping", false);
        anim.SetBool("IsIdle", true);
        //gun.position = player.position + gun.position;
    }

    void FixedUpdate()
    {

        //camera.position = player.position + space;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            Idle();
        }


    }

}
