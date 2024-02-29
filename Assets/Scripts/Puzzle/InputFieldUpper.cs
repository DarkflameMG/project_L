using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldUpper : MonoBehaviour
{
    [SerializeField]private TMP_InputField inputField;
    private void Start() {
        inputField.onValidateInput += delegate (string s, int i, char c) { return char.ToUpper(c); };
    }
}
