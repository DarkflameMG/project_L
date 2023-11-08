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
        int[] pos = missionSO.missionInfo.startPos;
        int width = missionSO.missionInfo.width;
        int hight = missionSO.missionInfo.hight;
        this.GetComponent<MapSystem>().SetStartLoc(pos[0],pos[1],width,hight);
        this.GetComponent<MapSystem>().SetStartRoom(Instantiate(allRoom.room1,mapSpawn),mapSpawn);
    }

    private void Start() 
    {
        InitMap();
    }
}
