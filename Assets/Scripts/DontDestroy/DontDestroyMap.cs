using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMap : MonoBehaviour
{
    [SerializeField]private GameObject map;
    [SerializeField]private RewardsSO rewardsSO;
    [SerializeField]private GateInventorySO gateInventorySO;
    // private bool toggle = false;

    private void Awake() {
        DontDestroyOnLoad(map);
        DontDestroyOnLoad(gameObject);
        if(GameObject.Find("MapScene") != null)
        {
            map = GameObject.Find("MapScene");
        }
    }

    private void Update() {
        // if(Input.GetKeyDown(KeyCode.B))
        // {
        //     map.SetActive(toggle);
        //     toggle = !toggle;
        //     Destroy(map);
        // }
        if(GameObject.Find("MapScene") != null)
        {
            map = GameObject.Find("MapScene");
        }
    }

    public void MapToFight()
    {
        map.SetActive(false);
    }

    public void FightToMap(bool win)
    {
        map.SetActive(true);
        if(win)
        {
            SetItem();
            map.GetComponent<ShowGateReward>().ShowUI();
        }
    }

    public void MapToLobby()
    {
        Destroy(map);
        ResetItem();
    }

    private void SetItem()
    {
        foreach(GateObjectConfig reward in rewardsSO.rewards)
        {
            if(reward.gateName.Equals("and"))
            {
                gateInventorySO.and += reward.used;
            }
            else if(reward.gateName.Equals("or"))
            {
                gateInventorySO.or += reward.used;
            }
            else if(reward.gateName.Equals("not"))
            {
                gateInventorySO.not += reward.used;
            }
            else if(reward.gateName.Equals("xor"))
            {
                gateInventorySO.xor += reward.used;
            }
            else if(reward.gateName.Equals("nand"))
            {
                gateInventorySO.nand += reward.used;
            }
            else if(reward.gateName.Equals("nor"))
            {
                gateInventorySO.nor += reward.used;
            }
            else if(reward.gateName.Equals("xnor"))
            {
                gateInventorySO.xnor += reward.used;
            }
            else if(reward.gateName.Equals("highVolt"))
            {
                gateInventorySO.highVolt += reward.used;
            }
            else if(reward.gateName.Equals("lowVolt"))
            {
                gateInventorySO.lowVolt += reward.used;
            }
            else if(reward.gateName.Equals("switch"))
            {
                gateInventorySO.switchs += reward.used;
            }
            else if(reward.gateName.Equals("bulb"))
            {
                gateInventorySO.bulb += reward.used;
            }
            else if(reward.gateName.Equals("splitter"))
            {
                gateInventorySO.splitter += reward.used;
            }
            else if(reward.gateName.Equals("placeHolder1"))
            {
                gateInventorySO.placeHolder1 += reward.used;
            }
            else if(reward.gateName.Equals("placeHolder2"))
            {
                gateInventorySO.placeHolder2 += reward.used;
            }
            else if(reward.gateName.Equals("line"))
            {
                gateInventorySO.line += reward.used;
            }
        }
    }

    private void ResetItem()
    {
        gateInventorySO.and = 0;
        gateInventorySO.or = 0;
        gateInventorySO.not = 0;
        gateInventorySO.xor = 0;
        gateInventorySO.nand = 0;
        gateInventorySO.nor = 0;
        gateInventorySO.xnor = 0;
        gateInventorySO.highVolt = 0;
        gateInventorySO.lowVolt = 0;
        gateInventorySO.switchs = 0;
        gateInventorySO.bulb = 0;
        gateInventorySO.splitter = 0;
        gateInventorySO.placeHolder1 = 0;
        gateInventorySO.placeHolder2 = 0;
        gateInventorySO.line = 0;
    }
}
