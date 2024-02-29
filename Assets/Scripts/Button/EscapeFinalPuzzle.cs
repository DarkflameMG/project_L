using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeFinalPuzzle : MonoBehaviour
{
    [SerializeField]private PlayFinalPuzzle playFinalPuzzle;
    [SerializeField]private Button escapeBtn;

    private void Awake() {
        escapeBtn.onClick.AddListener(Escape);
    }

    private void Escape()
    {
        playFinalPuzzle.Escape();
    }

}
