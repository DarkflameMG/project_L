using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AddCards : MonoBehaviour
{
    [SerializeField] private Transform puzzleField;
    [SerializeField] private GameObject cards;
    [SerializeField] public Sprite[] sprites;

    private void Awake() {
        for(int i = 0; i < 5; i++){
            int randomIndex = Random.Range(0, sprites.Length);
            GameObject button = Instantiate(cards, puzzleField.transform);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
            button.transform.localPosition = new Vector3(-3+(i*2), 0);
            button.GetComponent<SpriteRenderer>().sprite = sprites[randomIndex];
        }
    }
}
