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
    [SerializeField]private AllGateSpriteSO gates;
    private string currentName;
    private int count;
}
