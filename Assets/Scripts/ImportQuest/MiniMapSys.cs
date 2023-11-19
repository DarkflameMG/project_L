using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapSys : MonoBehaviour
{
    [SerializeField]private Transform roomPrefab;
    [SerializeField]private Transform emptyPrefab;
    [SerializeField]private MissionSO missionSO;
    [SerializeField]private Transform horizontalPrefab;
    [SerializeField]private Transform roomSpawnPoint;
    private RoomDetail[] rooms;
    private int hight,width;
    private void Awake() {
        rooms = missionSO.missionInfo.rooms;
        hight = missionSO.missionInfo.hight;
        width = missionSO.missionInfo.width;

        InitMap();
    }

    private void InitMap()
    {
        Transform horizontal = roomSpawnPoint;
        Transform prefab = roomPrefab;
        int j = -1;
        foreach(RoomDetail room in rooms)
        {
            if( j != room.y)
            {
                horizontal = Instantiate(horizontalPrefab,roomSpawnPoint);
                j++;
            }

            if(room.roomType == RoomType.none)
            {
                prefab = emptyPrefab;
            }
            else if(room.roomType == RoomType.room1)
            {
                prefab = roomPrefab;
            }
            Instantiate(prefab,horizontal);
        }
    }
}
