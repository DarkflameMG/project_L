using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSave : MonoBehaviour
{
    [SerializeField]private Transform confirmUI;
    private Button btn;
    private void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(confirm);
    }

    private void confirm()
    {
        confirmUI.gameObject.SetActive(true);
    }
}
