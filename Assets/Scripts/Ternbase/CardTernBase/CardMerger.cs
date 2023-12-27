using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMerger : MonoBehaviour
{
    private Card selectedCard;
    private Vector3 originalPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInputDown();
        }
        else if (Input.GetMouseButton(0))
        {
            HandleInputHold();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HandleInputUp();
        }
    }

    void HandleInputDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selectedCard = hit.collider.GetComponent<Card>();

            if (selectedCard != null)
            {
                originalPosition = selectedCard.transform.position;
            }
        }
    }

    void HandleInputHold()
    {
        if (selectedCard != null)
        {
            // Move the selected card based on mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                selectedCard.transform.position = new Vector3(hit.point.x, hit.point.y, originalPosition.z);
            }
        }
    }

    void HandleInputUp()
    {
        if (selectedCard != null)
        {
            // Snap the card back to its original position if not merged
            selectedCard.transform.position = originalPosition;

            // Attempt to merge the card with adjacent cards
            MergeAdjacentCards(selectedCard);

            selectedCard = null;  // Reset the selected card
        }
    }

    void MergeAdjacentCards(Card selectedCard)
    {
        Card[] cards = FindObjectsOfType<Card>();  // Find all cards in the scene

        // Iterate through all cards to find adjacent pairs for merging
        foreach (Card otherCard in cards)
        {
            if (otherCard != selectedCard)
            {
                // Check if the cards are adjacent (you might need to define adjacency rules)
                if (AreCardsAdjacent(selectedCard, otherCard))
                {
                    if (selectedCard.Merge(otherCard))
                    {
                        // Merge successful, update the UI or perform other actions as needed
                    }
                }
            }
        }
    }

    // Example adjacency check function (customize based on your game's rules)
    bool AreCardsAdjacent(Card card1, Card card2)
    {
        float distance = Vector3.Distance(card1.transform.position, card2.transform.position);
        return distance < 2.5f;  // Adjust the threshold as needed
    }
}
