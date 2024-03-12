using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
    [SerializeField] private Image[] starsEmpty;
    [SerializeField] private Image[] starsFull;

    public static int gems = 0;
    public static int cherries = 0;
    private int starsEarned;

    private void Start()
    {
        gems = ItemCollector.collectedGems;
        cherries = ItemCollector.collectedCherries;
        starsEarned = 0;
        DisableStars();
        CalculateEarnedStars();
        DisplayStars();
        Debug.Log("Stars earned: " + starsEarned);
        Debug.Log("Cherries: " + cherries);
        Debug.Log("Gems: " + gems);
    }

    private void DisplayStars()
    {
        switch (starsEarned)
        {
            case 0:
                foreach (var star in starsEmpty)
                {
                    star.enabled = true;
                }
                break;
            case 1:
                starsFull[0].enabled = true;
                starsEmpty[1].enabled = true;
                starsEmpty[2].enabled = true;
                break;
            case 2:
                starsFull[0].enabled = true;
                starsFull[1].enabled = true;
                starsEmpty[2].enabled = true;
                break;
            case 3:
                foreach (var star in starsFull)
                {
                    star.enabled = true;
                }
                break;
            default:
                break;
        }
    }

    private void DisableStars()
    {
        foreach (var star in starsEmpty)
        {
            star.enabled = false;
        }

        foreach (var star in starsFull)
        {
            star.enabled = false;
        }
    }

    private void CalculateEarnedStars()
    {
        if (gems >= 5 && cherries >= 10)
        {
            starsEarned = 3;
        }
        else if (gems >= 3 && cherries >= 6)
        {
            starsEarned = 2;
        }
        else if (gems >= 1 && cherries >= 2)
        {
            starsEarned = 1;
        }
    }
}
