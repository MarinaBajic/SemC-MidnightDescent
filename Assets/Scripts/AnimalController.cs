using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpForce = 10f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isFollowing = false;
    [SerializeField] private float followDistance = 3f;

    private enum MovementState { idle, walking, jumping, falling }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > followDistance)
        {
            isFollowing = true;
            Vector2 moveDirection = (playerTransform.position - transform.position).normalized;
            rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, rigidBody.velocity.y);

            if (IsGrounded() && ObstacleAhead())
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            }
        }
        else
        {
            isFollowing = false;
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (isFollowing && playerTransform.position.x > transform.position.x)
        {
            state = MovementState.walking;
            spriteRenderer.flipX = false;
        }
        else if (isFollowing && playerTransform.position.x < transform.position.x)
        {
            state = MovementState.walking;
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

    private bool ObstacleAhead()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.right, .1f, jumpableGround);
        return hit.collider != null;
    }

}
