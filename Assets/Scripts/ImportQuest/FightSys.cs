using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSys : MonoBehaviour
{
    [SerializeField]private RewardsSO rewardsSO;
    private List<GateObjectConfig> rewards;

    public void SetReward(List<GateObjectConfig> currentRewards)
    {
        rewards = currentRewards;
    }

    public void ConfirmReward()
    {
        rewardsSO.rewards = rewards;
    }

}
