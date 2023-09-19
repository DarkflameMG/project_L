using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelSave : MonoBehaviour
{
    [SerializeField]private Transform confirmUI;
    [SerializeField]private Transform TextInput;
    private Button btn;
    private void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Cancel);
    }

    private void Cancel()
    {
        TextInput.GetComponent<TMPro.TMP_InputField>().text = "";
        // Debug.Log(TextInput.GetComponent<TMPro.TMP_InputField>().text);
        confirmUI.gameObject.SetActive(false);
    }
}
