using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardValue = 1;  // The value of the card, you might have other attributes

    // Function to merge two cards
    public bool Merge(Card otherCard)
    {
        // Add your merging logic here based on your game's rules
        if (otherCard != null && otherCard.cardValue == this.cardValue)
        {
            // Merge successful
            this.cardValue *= 2;  // For simplicity, just double the value
            Destroy(otherCard.gameObject);  // Destroy the other card after merging
            return true;
        }

        // Merge failed
        return false;
    }
}

