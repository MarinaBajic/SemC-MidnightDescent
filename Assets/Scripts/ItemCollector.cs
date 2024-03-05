using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int gemsSum = 5;
    private int cherriesSum = 10;

    private int gemsCollected = 0;
    private int cherriesCollected = 0;

    [SerializeField] private TextMeshProUGUI gemsCounter;
    [SerializeField] private TextMeshProUGUI cherriesCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gemsCollected++;
            gemsCounter.text = "Gems: " + gemsCollected + "/" + gemsSum;
        }

        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherriesCollected++;
            cherriesCounter.text = "Gems: " + cherriesCollected + "/" + cherriesSum;
        }
    }
}
