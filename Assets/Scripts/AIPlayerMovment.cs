using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerMovment : MonoBehaviour {

    Animator anim;

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

}
