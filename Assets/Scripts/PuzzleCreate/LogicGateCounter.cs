using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicGateCounter : MonoBehaviour
{
    [SerializeField]private Image image;
    [SerializeField]private TMP_Text gateName;
    [SerializeField]private TMP_InputField inputField;
    private string currentName;
    // private int count;

    public void SetName(string name)
    {
        currentName = name;
    }

    public string GetName()
    {
        return currentName;
    }

    public int GetCount()
    {
        string input = inputField.text;
        if(input.Equals(""))
        {
            return 0;
        }
        return int.Parse(input);
    }
}
