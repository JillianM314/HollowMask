using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 moveDirection;

    public float speed = 2f;

    private float gravity = 20f;

    public float jumpForce = 6f;

    private float verticalVelocity;

    

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        Jump();
    }

    void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime; 

        ApplyGravity();

        characterController.Move(moveDirection);
    }

    void ApplyGravity()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;

            Jump();
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity * Time.deltaTime;
    }
    void Jump()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }

    
}
