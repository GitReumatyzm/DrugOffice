using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity = -9.81f;
    public static float playerSpeed = 10f;

    public DialaogueManagerScript dialaogueManagerS;

    private Vector3 velocity;

    [SerializeField] CharacterController playerController;

    [SerializeField] float groundDistance;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    private bool isGrounded;
    void Update()
    {
        PlayerMovementFunction();
        SkippingDaialogue();
    }

    public void PlayerMovementFunction()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        playerController.Move(move * playerSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);
     
    }
    public void SkippingDaialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialaogueManagerS.DisplayNextSentence();
        }

    }
}
