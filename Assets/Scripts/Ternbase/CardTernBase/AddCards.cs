using UnityEngine;

public class AddCards : MonoBehaviour
{
    [SerializeField] private Transform puzzleField;
    [SerializeField] private GameObject btns;
    [SerializeField] public Sprite[] sprites;

    private void Awake() {
        for(int i = 0; i < 5; i++){
            //int randomIndex = Random.Range(0, sprites.Length);
            GameObject button = Instantiate(btns, puzzleField.transform);
            button.name = "CardLV1_" + i;
            button.transform.SetParent(puzzleField, false);

            //button.GetComponent<Image>().sprite = sprites[randomIndex];
        }
    }
}
