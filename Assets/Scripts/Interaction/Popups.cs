using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    [SerializeField]private GameObject popup;
    [SerializeField]private GameObject keyPopup;
    [SerializeField]private Image keyCheck;
    [SerializeField]private TMP_Text keyName;
    [SerializeField]private Image keyImage;
    [SerializeField]private Sprite check;
    [SerializeField]private Sprite cross;
    [SerializeField]private KeySO keySO;

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
        int index = keySO.allKeys.IndexOf(name);
        keyImage.color = keySO.color[index];
        if(have)
        {
            keyCheck.sprite = check;
            keyCheck.color = new Color32(22,255,0,255);
        }
        else
        {
            keyCheck.sprite = cross;
            keyCheck.color = new Color32(255,0,0,255);
        }
    }
    
}
