using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDetailSys : MonoBehaviour
{
    [SerializeField]private RoomCatalogSys roomCatalogSys;
    [SerializeField]private TMP_Text monName;
    [SerializeField]private Image monImg;
    [SerializeField]private TMP_InputField hp;
    [SerializeField]private TMP_InputField atk;
    [SerializeField]private Button saveBtn;
    [SerializeField]private Transform rewards;
    [SerializeField]private GameObject roomcatalogUI;
    [SerializeField]private Transform gateCountPrefab;

    private void Awake() {
        saveBtn.onClick.AddListener(SaveMon);
    }

    private void SaveMon()
    {
        RoomSlot room = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>();
        List<GateObjectConfig> gates = new();
        MonsterDetail detail = new()
        {
            name = monName.text,
            hp = int.Parse(hp.text),
            atk = int.Parse(atk.text)
        };

        int childCount = rewards.childCount;
        for(int i=0;i<childCount;i++)
        {
            GateObjectConfig gate = new()
            {
                gateName = rewards.GetChild(i).GetComponent<LogicGateCounter>().GetName(),
                used = rewards.GetChild(i).GetComponent<LogicGateCounter>().GetCount()
            };
            gates.Add(gate);
        }
        detail.rewards = gates;

        room.SetCurrentMon(detail);

        roomcatalogUI.SetActive(false);
        DestroyRewards();
    }

    public void SetMonDetail()
    {
        DestroyRewards();
        RoomSlot room = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>();
        MonsterDetail detail = room.GetCurrentMon();
        monName.text = detail.name;
        hp.text = detail.hp.ToString();
        atk.text = detail.atk.ToString();

        foreach(GateObjectConfig gate in detail.rewards)
        {
            LogicGateCounter counter = Instantiate(gateCountPrefab,rewards).GetComponent<LogicGateCounter>();
            counter.SetName(gate.gateName);
            counter.SetNum(gate.used);
        }
    }

    public void DestroyRewards()
    {
        int childCount = rewards.childCount;
        for(int i=0;i<childCount;i++)
        {
            Destroy(rewards.GetChild(i).gameObject);
        }
    }
}
