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
    [SerializeField]private MonsterImgSO monsterImgSO;
    [SerializeField]private AllGateSpriteSO allGateSpriteSO;

    private void Awake() {
        saveBtn.onClick.AddListener(SaveMon);
    }

    private void SaveMon()
    {
        RoomSlot room = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>();
        List<GateObjectConfig> gates = new();
        Debug.Log(monName.text);
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
        SetMonName(detail.name);
        hp.text = detail.hp.ToString();
        atk.text = detail.atk.ToString();

        foreach(GateObjectConfig gate in detail.rewards)
        {
            LogicGateCounter counter = Instantiate(gateCountPrefab,rewards).GetComponent<LogicGateCounter>();
            counter.SetName(gate.gateName);
            counter.SetNum(gate.used);
            SetImg(counter,gate.gateName);
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

    public void SetMonName(string name)
    {
        monName.text = name;
        monImg.enabled = true;
        if(name.Equals("BrownWolf"))
        {
            monImg.sprite = monsterImgSO.brownWolf;
        }
        else if(name.Equals("GreenSnake"))
        {
            monImg.sprite = monsterImgSO.greenSnake;
        }
        else if(name.Equals("AbyssDog"))
        {
            monImg.sprite = monsterImgSO.abyssDog;
        }
        else if(name.Equals("GreenJelly"))
        {
            monImg.sprite = monsterImgSO.greenJelly;
        }
        else if(name.Equals("FireSalamandra"))
        {
            monImg.sprite = monsterImgSO.fireSalamandra;
        }
        else if(name.Equals("BlueSpirit"))
        {
            monImg.sprite = monsterImgSO.blueSpirit;
        }
        else if(name.Equals("BlackSpider"))
        {
            monImg.sprite = monsterImgSO.blackSpider;
        }
        else if(name.Equals("GreenBush"))
        {
            monImg.sprite = monsterImgSO.greenBush;
        }
        else if(name.Equals("RoyalManticora"))
        {
            monImg.sprite = monsterImgSO.royalManticora;
        }
        else
        {
            monImg.enabled = false;
        }
    }

    public void SetImg(LogicGateCounter counter,string gateName)
    {
        Sprite newSprite = allGateSpriteSO.and;

        if(gateName.Equals("and"))
        {
            newSprite = allGateSpriteSO.and;
        }
        else if(gateName.Equals("or"))
        {
            newSprite = allGateSpriteSO.or;
        }
        else if(gateName.Equals("not"))
        {
            newSprite = allGateSpriteSO.not;
        }
        else if(gateName.Equals("xor"))
        {
            newSprite = allGateSpriteSO.xor;
        }
        else if(gateName.Equals("nand"))
        {
            newSprite = allGateSpriteSO.nand;
        }
        else if(gateName.Equals("nor"))
        {
            newSprite = allGateSpriteSO.nor;
        }
        else if(gateName.Equals("xnor"))
        {
            newSprite = allGateSpriteSO.xnor;
        }
        else if(gateName.Equals("high volt"))
        {
            newSprite = allGateSpriteSO.highVolt;
        }
        else if(gateName.Equals("low volt"))
        {
            newSprite = allGateSpriteSO.lowVolt;
        }
        else if(gateName.Equals("switch"))
        {
            newSprite = allGateSpriteSO.switchs;
        }
        else if(gateName.Equals("bulb"))
        {
            newSprite = allGateSpriteSO.bulb;
        }
        else if(gateName.Equals("splitter"))
        {
            newSprite = allGateSpriteSO.splitter;
        }
        else if(gateName.Equals("placeholder1"))
        {
            newSprite = allGateSpriteSO.placeHolder1;
        }
        else if(gateName.Equals("placeholder2"))
        {
            newSprite = allGateSpriteSO.placeHolder2;
        }
        else if(gateName.Equals("line"))
        {
            newSprite = allGateSpriteSO.line;
        }

        counter.SetImg(newSprite);
    }
}
