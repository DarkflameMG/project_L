using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveConfig : MonoBehaviour
{
    [SerializeField]private TMP_InputField line;
    [SerializeField]private TMP_InputField and;
    [SerializeField]private TMP_InputField not;
    [SerializeField]private TMP_InputField or;
    [SerializeField]private RoomCatalogSys roomCatalogSys;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(UpdateConfig);
    }

    public void UpdateConfig()
    {
        RoomSlot room = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>();
        LogicGateConfig config = room.GetConfig();

        if(line.text.Equals(""))
        {
            line.text = "0";
        }
        if(not.text.Equals(""))
        {
            not.text = "0";
        }
        if(and.text.Equals(""))
        {
            and.text = "0";
        }
        if(or.text.Equals(""))
        {
            or.text = "0";
        }

        config.line = Int32.Parse(line.text);
        config.not = Int32.Parse(not.text);
        config.and = Int32.Parse(and.text);
        config.or = Int32.Parse(or.text);
    }

    public void UpdateInput()
    {
        RoomSlot room = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>();
        LogicGateConfig config = room.GetConfig();

        line.text = config.line.ToString();
        not.text = config.not.ToString();
        and.text = config.and.ToString();
        or.text = config.or.ToString();
    }
}
