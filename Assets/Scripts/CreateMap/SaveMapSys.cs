using System;
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
    [SerializeField]private Sprite cross;
    [SerializeField]private Sprite check;
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
            startCon.sprite = check;
        }   
        else if(!CheckStartRoom())
        {
            startCon.color = new Color32(255,0,0,255);
            startCon.sprite = cross;
        } 

        if(CheckExitRoom())
        {
            exitCon.color = new Color32(0,255,0,255);
            exitCon.sprite = check;
        }
        else if (!CheckExitRoom())
        {
            exitCon.color = new Color32(255,0,0,255);
            exitCon.sprite = cross;
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
        List<string> tables = new();
        int[] startPos = new int[2];
        int width = spawnRoomSlotSys.GetComponent<SpawnRoomSlotSys>().GetWidth();
        int hight = spawnRoomSlotSys.GetComponent<SpawnRoomSlotSys>().GetHight();
        rooms = GameObject.FindGameObjectsWithTag("roomSlot");
        RoomDetail[] roomsDetail = new RoomDetail[rooms.Length];

        int i=0;
        foreach(GameObject room in rooms)
        {
            RoomDetail roomDetail = new();
            DoorsDetail doorsDetail = new();

            RoomSlot roomSlot = room.GetComponent<RoomSlot>();
            RoomSlotDoor roomSlotDoor = room.GetComponent<RoomSlotDoor>();
            int[] pos = roomSlot.GetXY();
            RoomType roomType = roomSlot.GetRoomType();
            FeatureType featureType = roomSlot.GetFeatureType();
            LogicGateConfig config = roomSlot.GetConfig();
            string puzzleName = roomSlot.GetPuzzleName();
            MonsterDetail monsterDetail = roomSlot.GetCurrentMon();

            if(featureType == FeatureType.start)
            {
                startPos = pos;
            }
            else if(featureType == FeatureType.exit)
            {
                tables.Add(puzzleName);
            }
            else if(featureType == FeatureType.monster)
            {
                roomDetail.monster = monsterDetail;
            }

            if(featureType == FeatureType.exit || featureType == FeatureType.puzzle)
            {
                roomDetail.config = config;
            }

            int[] doorsFeature = roomSlotDoor.GetDoorFeature();
            string[] doorsKey = roomSlotDoor.GetKey();

            doorsDetail.front = SetDoorState(doorsFeature[0]);
            doorsDetail.back = SetDoorState(doorsFeature[1]);
            doorsDetail.left = SetDoorState(doorsFeature[2]);
            doorsDetail.right = SetDoorState(doorsFeature[3]);
            doorsDetail.frontKey = doorsKey[0];
            doorsDetail.backKey = doorsKey[1];
            doorsDetail.leftKey = doorsKey[2];
            doorsDetail.rightKey = doorsKey[3];

            roomDetail.x = pos[0];
            roomDetail.y = pos[1];
            roomDetail.Ftype = featureType;
            roomDetail.roomType = roomType;
            roomDetail.puzzleName = puzzleName;
            roomDetail.doors = doorsDetail;

            roomsDetail[i] = roomDetail;

            i++;
        }

        missionInfo.MissionName = missionName;
        missionInfo.width = width;
        missionInfo.hight = hight;
        missionInfo.startPos = startPos;
        missionInfo.rooms = roomsDetail;
        missionInfo.truthTables = tables;

        SaveAsJson(missionInfo);
    }

    private void SaveAsJson(MissionInfo missionInfo)
    {
        string json = JsonUtility.ToJson(missionInfo,true);
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/Map/"+missionInfo.MissionName+".json",json);
    }

    private DoorState SetDoorState(int doorsFeature)
    {
        if(doorsFeature == 0)
        {
            return DoorState.unlocked;
        }
        else if(doorsFeature == 1)
        {
            return DoorState.locked;
        }
        return DoorState.hide;
    }
}
