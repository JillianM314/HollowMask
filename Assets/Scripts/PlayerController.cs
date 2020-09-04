using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Iinput input;
    AgentMovement movement; 

    // Start is called before the first frame update
   private void OnEnable()
    {
        input = GetComponent<Iinput>();
        movement = GetComponent<AgentMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    private void OnDisable()
    {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
