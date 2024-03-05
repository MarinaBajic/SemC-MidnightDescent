using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    private float directionX;
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 12f;

    private enum MovementState { idle, walking, running, jumping, falling }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveSpeed = walkSpeed;
        directionX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        rigidBody.velocity = new Vector2(directionX * moveSpeed, rigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (directionX > 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                state = MovementState.running;
            }
            else
            {
                state = MovementState.walking;
            }
            spriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                state = MovementState.running;
            }
            else
            {
                state = MovementState.walking;
            }
                spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rigidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
