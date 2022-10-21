using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float sprintMultiplier = 2f;
    //[SerializeField] private float gravity = -9.81f;
    [SerializeField] private float gravity = -120;
    [SerializeField] private float jumpHeight = 3f;


    [SerializeField] private float groundDistance = 0.4f;
    [Tooltip("Walkable Mask")]
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    public AudioClip footStepSound;
    public float footStepDelay;

    private float nextFootstep = 0;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * (speed * sprintMultiplier) * Time.deltaTime);
        }
        else //SPRINT
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && isGrounded)
        {
            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
                nextFootstep += footStepDelay;
            }
        }
    }

}

