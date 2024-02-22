using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeBtn : MonoBehaviour
{
    [SerializeField]private WinSystem winSystem;
    Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Escape);
    }

    private void Escape()
    {
        winSystem.Escape();
    }
}
