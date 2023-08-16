using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    [SerializeField]MissionSO missionSO;
    [SerializeField]RoomsSO allRoom;
    [SerializeField]Transform mapSpawn;

    public void InitMap()
    {
        int[] pos = missionSO.missionInfo.map.startPoint;
        int maxX = missionSO.missionInfo.map.wide;
        int maxY = missionSO.missionInfo.map.high;
        this.GetComponent<MapSystem>().SetStartLoc(pos[0],pos[1],maxX,maxY);
        this.GetComponent<MapSystem>().SetStartRoom(Instantiate(allRoom.startRoom,mapSpawn),mapSpawn);
    }

    private void Start() 
    {
        InitMap();
    }
}
