using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBtn : MonoBehaviour
{
    [SerializeField]private TruthTableSys truthTableSys;
    [SerializeField]private KeyInventorySys keyInventorySys;
    [SerializeField]private bool isChest;
    Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ClickBtn);
    }

    public void ClickBtn()
    {
        if(isChest)
        {
            keyInventorySys.ToggleUI();
        }
        else
        {
            truthTableSys.ToggleUI();
        }
    }
    private void OnMouseEnter() 
    {
        
    }

    private void OnMouseExit() 
    {
        
    }
}
