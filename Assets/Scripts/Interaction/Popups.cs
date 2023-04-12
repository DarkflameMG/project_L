using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    [SerializeField]private GameObject popup;

    public void showPopup(string text)
    {
        popup.SetActive(true);
        popup.GetComponent<Text>().text = "[E]"+text;
    }

    public void closePopup()
    {
        popup.SetActive(false);
    }
    
}
