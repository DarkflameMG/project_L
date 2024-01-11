using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSave : MonoBehaviour
{
    [SerializeField]protected Transform confirmUI;
    private Button btn;
    private void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Confirm);
    }

    protected virtual void Confirm()
    {
        confirmUI.gameObject.SetActive(true);
    }
}
