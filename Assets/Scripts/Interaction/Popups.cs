using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    [SerializeField]private GameObject popup;
    [SerializeField]private GameObject keyPopup;
    [SerializeField]private TMP_Text keyNumber;
    [SerializeField]private TMP_Text keyName;

    public void ShowPopup(string text)
    {
        popup.SetActive(true);
        popup.GetComponent<Text>().text = "[E]"+text;
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
        if(keyPopup != null)
        {
            keyPopup.SetActive(false);
        }
    }

    public void ShowKeyPopup(string name,bool have)
    {
        keyPopup.SetActive(true);
        keyName.text = name;
        if(have)
        {
            keyNumber.text = "1 / 1";
            keyNumber.color = new Color32(22,255,0,255);
        }
        else
        {
            keyNumber.text = "0 / 1";
            keyNumber.color = new Color32(255,0,0,255);
        }
    }
    
}
