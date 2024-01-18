using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddNameIO : MonoBehaviour
{
    [SerializeField]private TMP_Text tmpText;
    private GameObject inputNameUI;

    private void Awake() {
        inputNameUI = transform.parent.GetComponent<Container>().GetItem();
    }

    public void ChangeText(string data)
    {
        tmpText.text = data;
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("right");
            inputNameUI.SetActive(true);
            inputNameUI.GetComponent<Container>().SetItem(gameObject);
        }
    }

    public String GetName()
    {
        return tmpText.text;
    }
}
