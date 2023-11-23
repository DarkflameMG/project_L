using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideGateSlot : MonoBehaviour
{
    [SerializeField]private GameObject gateSlot;
    private Button btn;
    private bool hideStatus= false;
    private void Awake() 
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ToggleHide);
    }

    private void ToggleHide()
    {
        if(hideStatus)
        {
            gateSlot.SetActive(true);
        }
        else
        {
            gateSlot.SetActive(false);
        }
        hideStatus = !hideStatus;
    }
}
