using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonUISys : MonoBehaviour
{
    [SerializeField]private MapSystem mapSystem;
    [SerializeField]private TMP_Text monName;
    [SerializeField]private TMP_Text hp;
    [SerializeField]private TMP_Text atk;
    [SerializeField]private Transform rewardPrefab;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private Image monImg;
    [SerializeField]private MonsterImgSO monsterImgSO;
    [SerializeField]private FightSys fightSys;
    private MonsterDetail monDetail;
    private bool toggle = true;

    public void SetMonUI()
    {
        if(toggle)
        {
            monDetail = mapSystem.GetCurrentRoomDetail().monster;
        
            monName.text = monDetail.name;
            hp.text = monDetail.hp.ToString();
            atk.text = monDetail.atk.ToString();
            SetMonImg(monDetail.name);
            List<GateObjectConfig> rewards = monDetail.rewards;
            fightSys.SetReward(rewards);

            foreach(GateObjectConfig a_reward in rewards)
            {
                GateNumberSetting gate = Instantiate(rewardPrefab,spawnPoint).GetComponent<GateNumberSetting>();
                gate.SetGate(a_reward.gateName,a_reward.used);
            }
            toggle = false;
        }

    }

    public void ResetUI()
    {
        int count = spawnPoint.childCount;
        for(int i=0;i<count;i++)
        {
            Destroy(spawnPoint.GetChild(i).gameObject);
        }
        toggle = true;
    }

    private void SetMonImg(string name)
    {
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
            // monImg.enabled = false;
        }
    }
}
