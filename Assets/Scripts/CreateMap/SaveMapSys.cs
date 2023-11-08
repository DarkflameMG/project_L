using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMapSys : MonoBehaviour
{
    [SerializeField]private Transform startRoomStatusImg;
    [SerializeField]private Transform exitRoomStatusImg;
    [SerializeField]private Transform roomCatalogSys;
    [SerializeField]private Transform spawnRoomSlotSys;
    private bool haveStartRoom = false;
    private bool haveExitRoom = false;
    private Image startCon;
    private Image exitCon;
    private GameObject[] rooms; 

    private void Awake() {
        startCon = startRoomStatusImg.GetComponent<Image>();
        exitCon = exitRoomStatusImg.GetComponent<Image>();
    }

    // public void SetHaveStartRoom(bool data)
    // {
    //     haveStartRoom = data;
    // }

    private void Update() 
    {
        if(CheckStartRoom())
        {
            startCon.color = new Color32(0,255,0,255);
        }   
        else if(!CheckStartRoom())
        {
            startCon.color = new Color32(255,0,0,255);
        } 

        if(CheckExitRoom())
        {
            exitCon.color = new Color32(0,255,0,255);
        }
        else if (!CheckExitRoom())
        {
            exitCon.color = new Color32(255,0,0,255);
        }
    }

    private bool CheckStartRoom()
    {
        haveStartRoom = roomCatalogSys.GetComponent<RoomCatalogSys>().GetStartRoom() != null;
        return haveStartRoom;
    }

    private bool CheckExitRoom()
    {
        haveExitRoom = roomCatalogSys.GetComponent<RoomCatalogSys>().GetExitRoom() != null;
        return haveExitRoom;
    }

    public void BeforeStartSave(string missionName)
    {
        if(haveExitRoom && haveStartRoom)
        {
            StartSave(missionName);
        }
        else
        {
            Debug.Log("condition not fullfill");
        }
    }

    private void StartSave(string missionName)
    {
        MissionInfo missionInfo = new();
        int[] startPos = new int[2];
        int width = spawnRoomSlotSys.GetComponent<SpawnRoomSlotSys>().GetWidth();
        int hight = spawnRoomSlotSys.GetComponent<SpawnRoomSlotSys>().GetHight();
        rooms = GameObject.FindGameObjectsWithTag("roomSlot");
        RoomDetail[] roomsDetail = new RoomDetail[rooms.Length];

        int i=0;
        foreach(GameObject room in rooms)
        {
            RoomDetail roomDetail = new();

            RoomSlot roomSlot = room.GetComponent<RoomSlot>();
            int[] pos = roomSlot.GetXY();
            RoomType roomType = roomSlot.GetRoomType();
            FeatureType featureType = roomSlot.GetFeatureType();
            if(featureType == FeatureType.start)
            {
                startPos = pos;
            }

            roomDetail.x = pos[0];
            roomDetail.y = pos[1];
            roomDetail.Ftype = featureType;
            roomDetail.roomType = roomType;

            roomsDetail[i] = roomDetail;

            i++;
        }

        missionInfo.MissionName = missionName;
        missionInfo.width = width;
        missionInfo.hight = hight;
        missionInfo.startPos = startPos;
        missionInfo.rooms = roomsDetail;

        SaveAsJson(missionInfo);
    }

    private void SaveAsJson(MissionInfo missionInfo)
    {
        string json = JsonUtility.ToJson(missionInfo,true);
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/Map/"+missionInfo.MissionName+".json",json);
    }
}
