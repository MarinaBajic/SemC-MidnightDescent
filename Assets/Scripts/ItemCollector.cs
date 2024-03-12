using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int totalGems = 5;
    public int totalCherries = 10;

    public static int collectedGems = 0;
    public static int collectedCherries = 0;

    [SerializeField] private TextMeshProUGUI counterGems;
    [SerializeField] private TextMeshProUGUI counterCherries;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            collectedGems++;
            counterGems.text = "Gems:  " + collectedGems + "/" + totalGems;
        }

        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            collectedCherries++;
            counterCherries.text = "Cherries:  " + collectedCherries + "/" + totalCherries;
        }
    }
}
