using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmName : ConfirmSave
{
    [SerializeField]private TMP_InputField tMP_Input;
    protected override void Confirm()
    {
        AddNameIO obj = confirmUI.GetComponent<Container>().GetItem().GetComponent<AddNameIO>();
        obj.ChangeText(tMP_Input.text);
        confirmUI.gameObject.SetActive(false);
        tMP_Input.text = "";
    }
}
