using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    [SerializeField]MapLocSO mapLoc;
    [SerializeField]LobbyInfo mapInfo;
    [SerializeField]RoomsSO allRoom;

    private Transform currentRoom;
    public void setStartLoc(int x,int y,int maxX,int maxY)
    {
        mapLoc.current_x = x;
        mapLoc.current_y = y;
        mapLoc.max_x = maxX;
        mapLoc.max_y = maxY;
    }

    public void setStartRoom(Transform room)
    {
        currentRoom = room;
    }

    public void changeRoom()
    {
        mapInfo.Busy = false;
        Debug.Log(currentRoom);
    }
}
