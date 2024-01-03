using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MiniMapSys : MonoBehaviour
{
    [SerializeField]private Transform roomPrefab;
    [SerializeField]private Transform emptyPrefab;
    [SerializeField]private MissionSO missionSO;
    [SerializeField]private Transform horizontalPrefab;
    [SerializeField]private Transform roomSpawnPoint;
    [SerializeField]private Camera mapCamera;
    [SerializeField]private Transform flagCurrent;
    [SerializeField]private Transform vertical;
    [SerializeField]private ScrollRect scrollView;
    [SerializeField]private Transform viewPort;
    private RoomDetail[] rooms;
    private Transform currentRoom;
    private string currentRoomName;
    private int hight,width;
    private bool mapStatus = true;
    private void Awake() {
        rooms = missionSO.missionInfo.rooms;
        hight = missionSO.missionInfo.hight;
        width = missionSO.missionInfo.width;

        InitMap();
    }

    private void Update() {
        if(Keyboard.current.mKey.wasPressedThisFrame)
        {
            ToggleMap();
        }
        if(currentRoom.name != currentRoomName)
        {
            currentRoom = GameObject.Find(currentRoomName).transform;
        }
        if(mapStatus)
        {
            CenterPosition();
        }
        UpdatePosition();
        
    }

    private void InitMap()
    {
        Transform horizontal = roomSpawnPoint;
        Transform prefab = roomPrefab;
        Transform spawnRoom;
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
            spawnRoom = Instantiate(prefab,horizontal);
            spawnRoom.name = "Room"+room.x+"_"+room.y;

            if(room.Ftype == FeatureType.start)
            {
                currentRoom = spawnRoom;
                currentRoomName = currentRoom.name;
            }
        }
    }

    private void ToggleMap()
    {
        mapStatus = !mapStatus;
        if(mapStatus)
        {
            mapCamera.rect = new Rect(0.8f,0,1,0.2f);
            scrollView.horizontal = false;
            scrollView.vertical = false;
        }
        else
        {
            mapCamera.rect = new Rect(0,0,1,1);
            scrollView.horizontal = true;
            scrollView.vertical = true;
        }
    }

    public void UpdatePosition()
    {
        flagCurrent.localPosition = currentRoom.localPosition + currentRoom.parent.localPosition + vertical.localPosition;
    }

    public void SetCurrentRoom(string roomName)
    {
        currentRoomName = roomName;
    }

    public void CenterPosition()
    {
        viewPort.localPosition = new Vector3(-flagCurrent.localPosition.x,-flagCurrent.localPosition.y);
    }
}