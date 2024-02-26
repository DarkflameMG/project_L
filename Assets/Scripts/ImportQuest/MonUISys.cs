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
            List<GateObjectConfig> rewards = monDetail.rewards;

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
}
