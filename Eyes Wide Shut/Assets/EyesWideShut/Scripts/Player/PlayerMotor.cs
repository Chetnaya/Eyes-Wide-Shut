using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public AudioSource footstepSound;
    private bool isMoving; // add a variable to track if the player is moving

    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        // Stop the footstep sound if the player is not moving
        if (!isMoving && footstepSound.isPlaying)
        {
            footstepSound.Stop();
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // Check if the player is moving and play the footstep sound
        if (moveDirection.magnitude > 0 && isGrounded && !footstepSound.isPlaying)
        {
            footstepSound.Play();
            isMoving = true; // set isMoving to true if the player is moving
        }
        else if (moveDirection.magnitude == 0 && footstepSound.isPlaying)
        {
            footstepSound.Stop();
            isMoving = false; // set isMoving to false if the player stops moving
        }

        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
