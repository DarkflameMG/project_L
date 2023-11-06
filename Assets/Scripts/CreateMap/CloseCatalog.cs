using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseCatalog : MonoBehaviour
{
    [SerializeField]private GameObject mainCatalog;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        mainCatalog.SetActive(false);
        // transform.parent.gameObject.SetActive(false);
    }
}
