using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    [SerializeField]private MissionSO missionSO;
    public void setCurerntMission(MissionInfo data)
    {
        missionSO.missionInfo = data;
    }

    public MissionInfo GetMissionInfo()
    {
        return missionSO.missionInfo;
    }
}
