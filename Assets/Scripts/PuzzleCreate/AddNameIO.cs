using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddNameIO : MonoBehaviour
{
    [SerializeField]private TMP_Text tmpText;
    private GameObject inputNameUI;
    private KeyInventorySys keyInventorySys;
    private MiniMapSys miniMapSys;

    private void Awake() {
        inputNameUI = transform.parent.GetComponent<Container>().GetItem();
        if(GameObject.Find("KeyInventorySys") != null)
        {
            keyInventorySys = GameObject.Find("KeyInventorySys").GetComponent<KeyInventorySys>();
        }
        if(GameObject.Find("MiniMapSys") != null)
        {
            miniMapSys = GameObject.Find("MiniMapSys").GetComponent<MiniMapSys>();
        }
    }

    public void ChangeText(string data)
    {
        tmpText.text = data;
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(1))
        {
            // Debug.Log("right");
            inputNameUI.SetActive(true);
            inputNameUI.GetComponent<Container>().SetItem(gameObject);
            keyInventorySys.SetCanToggleFalse();
            miniMapSys.SetCanToggleFalse();
        }
    }

    public String GetName()
    {
        return tmpText.text;
    }
}
