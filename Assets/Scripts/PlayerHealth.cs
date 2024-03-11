using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int health;

    [SerializeField] private TextMeshProUGUI healthStatus;

    private Animator animator;

    private void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("hurt");

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("dead");
            Destroy(gameObject);
        }

        healthStatus.text = "Health:  " + health;
    }
}
