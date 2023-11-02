using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseCatalog : MonoBehaviour
{
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
