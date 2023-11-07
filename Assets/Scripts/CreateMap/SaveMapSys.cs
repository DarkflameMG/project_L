using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMapSys : MonoBehaviour
{
    [SerializeField]private Transform startRoomStatusImg;
    [SerializeField]private Transform exitRoomStatusImg;
    [SerializeField]private Transform roomCatalogSys;
    private bool haveStartRoom = false;
    private bool haveExitRoom = false;
    private Image startCon;
    private Image exitCon;
    private GameObject[] rooms; 

    private void Awake() {
        startCon = startRoomStatusImg.GetComponent<Image>();
        exitCon = exitRoomStatusImg.GetComponent<Image>();
    }

    public void SetHaveStartRoom(bool data)
    {
        haveStartRoom = data;
    }

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

    public void BeforeStartSave()
    {
        if(haveExitRoom && haveStartRoom)
        {
            StartSave();
        }
        else
        {
            Debug.Log("condition not fullfill");
        }
    }

    private void StartSave()
    {
        rooms = GameObject.FindGameObjectsWithTag("roomSlot");
        Debug.Log(rooms.Length);
    }
}
