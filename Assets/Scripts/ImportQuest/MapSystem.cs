using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    [SerializeField]MapLocSO mapLoc;
    [SerializeField]LobbyInfo mapInfo;
    [SerializeField]RoomsSO allRoom;
    [SerializeField]Transform player;

    private Transform currentRoom;
    private Transform mapspawn;
    public void setStartLoc(int x,int y,int maxX,int maxY)
    {
        mapLoc.current_x = x;
        mapLoc.current_y = y;
        mapLoc.max_x = maxX;
        mapLoc.max_y = maxY;
    }

    public void setStartRoom(Transform room,Transform spawnLoc)
    {
        currentRoom = room;
        mapspawn = spawnLoc;
    }

    public void ChangeRoom(RoomSide side)
    {
        mapInfo.Busy = false;
        Debug.Log(currentRoom);
        player.position = Vector3.zero;
        Destroy(currentRoom.gameObject);
        currentRoom = Instantiate(allRoom.startRoom,mapspawn);
        if(side == RoomSide.right)
        {
            player.position = new Vector3 (-6.4f,0,0);
        }
        else if(side == RoomSide.left)
        {
            player.position = new Vector3 (6.4f,0,0);
        }
        else if(side == RoomSide.back)
        {
            player.position = new Vector3 (0,0,6.4f);
        }
        else if(side == RoomSide.front)
        {
            player.position = new Vector3 (0,0,-7.4f);
        }
    }
}
