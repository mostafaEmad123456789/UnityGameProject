using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator anim;

    Transform player;

    public Transform gun;

    public Transform camera;

    Vector3 space = new Vector3(0, 2f, -0.4f);

    Vector3 gunSpace = new Vector3(-0.2f, 0, -0.2f);

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Transform>();
    }
    void FixedUpdate()
    {

        camera.position = player.position + space;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("IsWalkingForward", true);
            anim.SetBool("IsWalkingBackward", false);
            anim.SetBool("IsWalkingRight", false);
            anim.SetBool("IsWalkingLeft", false);
            
            anim.SetBool("IsIdle", false);
            //gun.position = player.position + gun.position;
            transform.Translate(0, 0, 0.1f);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("IsWalkingForward", false);
            anim.SetBool("IsWalkingBackward", true);
            anim.SetBool("IsWalkingRight", false);
            anim.SetBool("IsWalkingLeft", false);
           
            anim.SetBool("IsIdle", false);
            //gun.position = player.position + gun.position;
            transform.Translate(0, 0, -0.1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("IsWalkingForward", false);
            anim.SetBool("IsWalkingBackward", false);
            anim.SetBool("IsWalkingRight", true);
            anim.SetBool("IsWalkingLeft", false);
            
            anim.SetBool("IsIdle", false);
            // gun.position = player.position + gun.position;
            transform.Translate(0.1f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("IsWalkingForward", false);
            anim.SetBool("IsWalkingBackward", false);
            anim.SetBool("IsWalkingRight", false);
            anim.SetBool("IsWalkingLeft", true);
            
            anim.SetBool("IsIdle", false);
            // gun.position = player.position + gun.position;
            transform.Translate(-0.1f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("IsWalkingForward", false);
            anim.SetBool("IsWalkingBackward", false);
            anim.SetBool("IsWalkingRight", false);
            anim.SetBool("IsWalkingLeft", false);
            anim.SetTrigger("IsJumping");
            anim.SetBool("IsIdle", false);
            // gun.position = player.position + gun.position;
            transform.Translate(0, 0.1f, 0);
        }
        else
        {
            anim.SetBool("IsWalkingForward", false);
            anim.SetBool("IsWalkingBackward", false);
            anim.SetBool("IsWalkingRight", false);
            anim.SetBool("IsWalkingLeft", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsIdle", true);
            //gun.position = player.position + gun.position;
        }

        
    }

}
