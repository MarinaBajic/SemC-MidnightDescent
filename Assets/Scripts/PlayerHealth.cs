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

    private void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
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
        animator.SetTrigger("dead");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
