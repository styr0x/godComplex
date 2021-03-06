﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    float speed, runSpeed, jumpHeight, gravity, crouchHeight;
    Vector3 gravityVelocity;

    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("canMove") == true)
        {
            Crouch();
            Gravity();
            Jump();
            Move();

        }
        else if (animator.GetBool("canMove") == false)
        {

        }

    }
    
    private void Gravity()
    {

        if (controller.isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
        }


        gravityVelocity.y += gravity * Time.deltaTime;
        controller.Move(gravityVelocity * Time.deltaTime);

    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && controller.isGrounded == true)
        {
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //Debug.Log("Jump");
        }

    }

    private void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("left shift"))
        {
            animator.SetBool("isRunning", true);
            speed += runSpeed;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            animator.SetBool("isRunning", false);
            speed -= runSpeed;
        }

        Vector3 move = transform.forward * z + transform.right * x;
        controller.Move(speed * move * Time.deltaTime);

        //Debug.Log(z);

    }

    private void Crouch()
    {
        if (Input.GetKeyDown("left ctrl"))
        {
            controller.height -= crouchHeight;
        }
        else if (Input.GetKeyUp("left ctrl"))
        {
            controller.height += crouchHeight;
        }
    }
}
