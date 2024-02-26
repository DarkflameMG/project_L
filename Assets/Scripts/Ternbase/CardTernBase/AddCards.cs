using UnityEngine;

public class AddCards : MonoBehaviour
{
    [SerializeField] private Transform puzzleField;
    [SerializeField] private GameObject btns;

    private void Awake() {
        for(int i = 0; i < 5; i++){

            GameObject button = Instantiate(btns, puzzleField.transform);
            button.name = "CardLV1_" + i;
            button.transform.SetParent(puzzleField, false);
        }
    }
}
