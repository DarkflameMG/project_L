using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour,IInteractable
{
    [SerializeField]private MapLocSO mapLoc;
    [SerializeField]private int delta_x;
    [SerializeField]private int delta_y;
    [SerializeField]private RoomSide side;
    [SerializeField]private MissionSO missionSO;
    private RoomDetail[] rooms;
    private GameObject popupSystem;
    private MapSystem mapSystem;
    private int x,y;
    private bool isLocked = false;
    private string key;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        mapSystem = GameObject.Find("SpawnMapSys").GetComponent<MapSystem>();
    }

    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        // x = mapLoc.current_x + delta_x;
        // y = mapLoc.current_y + delta_y;

        if(CantInteract())
        {
            // nothing happen
        }
        else
        {
            mapLoc.current_x = x;
            mapLoc.current_y = y;
            mapSystem.ChangeRoom(side);
        }
        return false;
    }

    public bool ShowPopup()
    {
        string text = CheckIfLocked();
        popupSystem.GetComponent<Popups>().showPopup(text);
        return true;
    }

    public bool CantInteract()
    {
        x = mapLoc.current_x + delta_x;
        y = mapLoc.current_y + delta_y;
        bool outOfBound = 0 > x || 0 > y || x > mapLoc.width-1 || y > mapLoc.hight-1;
        bool noneRoomType = CheckNextRoomType(x,y) == RoomType.none;
        bool result = outOfBound || noneRoomType;
        return result;
    }

    private RoomType CheckNextRoomType(int x,int y)
    {
        rooms = missionSO.missionInfo.rooms;
        foreach(RoomDetail room in rooms)
        {
            if(room.x == x && room.y == y)
            {
                return room.roomType;
            }
        }
        return RoomType.none;
    }

    public string CheckIfLocked()
    {
        if(isLocked)
        {
            return "Key : "+key+" require";
        }
        return "Open";
    }

    public void SetLocked(bool data,string key)
    {
        isLocked = data;
        this.key = key;
    }
    
}