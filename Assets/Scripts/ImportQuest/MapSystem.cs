using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    [SerializeField]MapLocSO mapLoc;
    [SerializeField]LobbyInfo mapInfo;

    public void setStartLoc(int x,int y)
    {
        mapLoc.current_x = x;
        mapLoc.current_y = y;
    }

    public void changeRoom()
    {
        mapInfo.Busy = false;
    }
}
