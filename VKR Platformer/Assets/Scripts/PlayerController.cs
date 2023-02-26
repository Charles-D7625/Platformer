using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float movementInputDirection;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool canJump;

    public float movementSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float groundCheckRadius;

    public Transform groundCheck;

    public LayerMask whatIsGroud;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDiration();
        UpdateAnimations();
        CheckIfCanJump();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurrounding();
    }

    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGroud);
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0.05)
        {
            canJump= true;
        }
        else
        {
            canJump= false;
        }
    }

    private void CheckMovementDiration()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            FlipCharacter();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            FlipCharacter();
        }

        if(rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("IsWalking", isWalking);
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
