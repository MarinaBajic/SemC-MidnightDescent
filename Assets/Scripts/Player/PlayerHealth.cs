using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int health;

    [SerializeField] private TextMeshProUGUI healthStatus;

    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        hurtSoundEffect.Play();
        animator.SetTrigger("hurt");

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        healthStatus.text = "Health:  " + health;
    }

    private void Die()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
        animator.SetTrigger("dead");
    }

    private void RestartLevel()
    {
        ItemCollector.collectedGems = 0;
        ItemCollector.collectedCherries = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
