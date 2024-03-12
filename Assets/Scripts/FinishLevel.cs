using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene("Level Complete Screen");
    }

}
