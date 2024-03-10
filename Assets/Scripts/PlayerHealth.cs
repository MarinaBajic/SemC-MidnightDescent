using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int health;

    [SerializeField] private TextMeshProUGUI healthStatus;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            healthStatus.text = "Health:  dead";
            Destroy(gameObject);
            return;
        }

        healthStatus.text = "Health:  " + health;
    }
}
