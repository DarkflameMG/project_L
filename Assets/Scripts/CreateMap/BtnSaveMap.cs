using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSaveMap : MonoBehaviour
{
    [SerializeField]private bool isConfirmBtn;
    [SerializeField]private GameObject confirmUI;
    [SerializeField]private Transform saveMapSys;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(BtnType);
    }

    private void BtnType()
    {
        if(isConfirmBtn)
        {
            saveMapSys.GetComponent<SaveMapSys>().BeforeStartSave();
            confirmUI.SetActive(false);
        }
        else
        {
            confirmUI.SetActive(true);
        }
    }
}
