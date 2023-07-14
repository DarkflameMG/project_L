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
        int maxX = missionSO.missionInfo.map.wide;
        int maxY = missionSO.missionInfo.map.high;
        this.GetComponent<MapSystem>().setStartLoc(pos[0],pos[1],maxX,maxY);
        this.GetComponent<MapSystem>().setStartRoom(Instantiate(allRoom.startRoom,mapSpawn),mapSpawn);
    }

    private void Start() 
    {
        initMap();
    }
}
