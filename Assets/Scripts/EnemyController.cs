 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1;
    [SerializeField] private float range = 1;
    [SerializeField] private int damage = 2;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private CapsuleCollider2D capsuleCollider;
    private Animator animator;

    [SerializeField] private AudioSource enemyAudioSource;
    [SerializeField] private AudioSource backgroundMusic;

    private PlayerHealth playerHealth;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("enemyAttack");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            capsuleCollider.bounds.center + range * transform.localScale.x * transform.right, 
            capsuleCollider.bounds.size, 0f, Vector2.left, 0f, playerLayer);
        
        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<PlayerHealth>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            capsuleCollider.bounds.center + range * transform.localScale.x * transform.right,
            capsuleCollider.bounds.size);
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        backgroundMusic.Pause();
        enemyAudioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyAudioSource.Pause();
        backgroundMusic.Play();
    }

}
