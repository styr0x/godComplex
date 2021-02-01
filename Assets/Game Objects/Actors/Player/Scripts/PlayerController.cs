using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;


    public float speed = 6f;
    public float runSpeed = 2f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float crouchHeight = 0.5f;


    Vector3 gravityVelocity;


    // Update is called once per frame
    void Update()
    {
        Gravity();
        Jump();
        Move();
        Crouch();
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
            speed += runSpeed;
        }
        else if (Input.GetKeyUp("left shift"))
        {
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
