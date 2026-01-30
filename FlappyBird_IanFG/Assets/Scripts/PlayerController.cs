using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = 9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;

    public int numSaltos = 0;
    public int maxSaltos = 2;
    public Animator animatorController;
    private Vector3 move;
    private bool isRunning;
    private bool isJumping;



    bool salto;
    bool suelo;

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        
    }

    
    void Update()
    {
        Movement();
        Animations();


    }

    public void Movement()
    {

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2.0f)
                playerVelocity.y = -2.0f;
        }

        // Read input
        Vector2 input;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        
        move = new Vector3(x, 0.0f, y);

        // normalize move vector to prevent faster diagonal movement
        move = Vector3.ClampMagnitude(move, 1.0f);

        // we ask wether there is some movement to rotate the player
        // we press any key to move, we rotate the player to face that direction
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // running speed 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning =false;
        }

        //animator.SetBool("Salto", salto);
        //animator.SetBool("TocoSuelo", suelo);


        // Jump using WasPressedThisFrame()
        if (Input.GetKeyDown(KeyCode.Space) && numSaltos != 0)
        {

            // Calculate jump velocity and -2 so that we reach the desired height with gravity pulling us down
            playerVelocity.y = Mathf.Sqrt(jumpHeight * gravityValue);

            isJumping = true;

            salto = true;
            suelo = false;
            numSaltos--;

            // numSa


        }


        if (groundedPlayer && numSaltos == 0)
        {
            numSaltos = maxSaltos;
            salto = false;
            suelo = true;
        }

        // Apply gravity
        playerVelocity.y -= gravityValue * Time.deltaTime;

        // Move
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);

        //animator.SetFloat("Velx", x);
        //animator.SetFloat("Vely", y);

    }

    public void Animations()
    {
        if (move != Vector3.zero)
        {
            animatorController.SetBool("IsWalking", true);
        }
        else
        {
            animatorController.SetBool("IsWalking", false);
        }


        animatorController.SetBool("IsRunning", isRunning);

        animatorController.SetBool("IsJumping", isJumping);

        /*if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            animatorController.SetBool("isRunning", true);
        }
        else
        {
            animatorController.SetBool("isRunning", false);
        }*/



    }
    public void Start()
    {
        
        //animator = GetComponent<Animator>();
    }
}
