using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    [SerializeField]MissionSO missionSO;
    [SerializeField]RoomsSO allRoom;
    [SerializeField]Transform mapSpawn;

    public void initMap()
    {
        int[] pos = missionSO.missionInfo.map.startPoint;
        this.GetComponent<MapSystem>().setStartLoc(pos[0],pos[1]);
        Instantiate(allRoom.startRoom,mapSpawn);
    }

    private void Start() 
    {
        initMap();
    }
}
