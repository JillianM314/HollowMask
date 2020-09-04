using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    CharacterController characterController;
    public float rotationSpeed, movementSpeed, gravity = 20;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;
    private float inputVerticalDirection = 0;

    private float verticalVelocity;

    //private Vector3 moveDirection = Vector3.zero;
    

    public float jumpForce = 6f;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (characterController.isGrounded)
        {
            if(movementVector.magnitude > 0)
            {
                RotateAgent();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movementVector.y = jumpForce;
            }
        }

        movementVector.y -= gravity;
        characterController.Move(movementVector * Time.deltaTime);
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
        if (crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if(desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed *Time.deltaTime);
        }
    }

    public void HandleMovement(Vector2 input)
    {
        if (characterController.isGrounded)
        {
            if(input.y != 0)
            {
                if(input.y > 0)
                {
                    inputVerticalDirection = Mathf.CeilToInt(input.y);
                }
                else
                {
                    inputVerticalDirection = Mathf.FloorToInt(input.y);
                }
                movementVector = input.y*transform.forward * movementSpeed;
            }
            else
            {
                movementVector = Vector3.zero;
            }
        }
    }

}
