using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMapSys : MonoBehaviour
{
    [SerializeField]private Transform startRoomStatusImg;
    [SerializeField]private Transform bossRoomStatusImg;
    private bool haveStartRoom;
    private bool haveBossRoom;

    public void SetHaveStartRoom(bool data)
    {
        haveStartRoom = data;
    }
}
