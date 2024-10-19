using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravityValue = -5;

    float moveX;
    float moveY;
    float moveZ;
    Vector3 velocity;
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        if (transform.position.y > 1.1f)
        {
            moveY = gravityValue;
        }

        MovePlayer(moveX, moveY, moveZ);

        velocity.y += gravityValue * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void MovePlayer(float moveX, float moveY, float moveZ)
    {
       
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

       
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
}
