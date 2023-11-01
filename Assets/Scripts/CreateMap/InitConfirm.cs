using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class InitConfirm : MonoBehaviour
{
    [SerializeField]private Transform textX;
    [SerializeField]private Transform textY;
    [SerializeField]private Transform spawnRoomSlotSys;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ConfirmInit);
    }

    private void ConfirmInit()
    {
        int x,y;
        x = Int32.Parse(textX.GetComponent<TMPro.TMP_InputField>().text);
        y = Int32.Parse(textY.GetComponent<TMPro.TMP_InputField>().text);

        spawnRoomSlotSys.GetComponent<SpawnRoomSlotSys>().StartCreateMap(x,y);
    }
}
