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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wizard"))
        {
            health -= 2;

            if (health <= 0)
            {
                Destroy(gameObject);
                return;
            }

            healthStatus.text = "Health:  " + health;
        }
    }
}
