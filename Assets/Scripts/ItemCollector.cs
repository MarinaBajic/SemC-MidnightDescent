using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public static int totalGems = 5;
    public static int totalCherries = 10;

    public static int collectedGems = 0;
    public static int collectedCherries = 0;

    private GameObject collectedItem;

    [SerializeField] private TextMeshProUGUI counterGems;
    [SerializeField] private TextMeshProUGUI counterCherries;

    [SerializeField] private AudioSource collectAudioSource;

    private void Start()
    {
        counterGems.text = "Gems:  " + collectedGems + "/" + totalGems;
        counterCherries.text = "Cherries:  " + collectedCherries + "/" + totalCherries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem") || collision.gameObject.CompareTag("Cherry"))
        {
            collectedItem = collision.gameObject;
            collectAudioSource.Play();
            collectedItem.GetComponent<Animator>().SetTrigger("collected");
            Invoke("RemoveItem", 0.5f);
        }

        if (collision.gameObject.CompareTag("Gem"))
        {
            collectedGems++;
            counterGems.text = "Gems:  " + collectedGems + "/" + totalGems;
        }

        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectedCherries++;
            counterCherries.text = "Cherries:  " + collectedCherries + "/" + totalCherries;
        }
    }

    public void RemoveItem()
    {
        Destroy(collectedItem);
    }
}
