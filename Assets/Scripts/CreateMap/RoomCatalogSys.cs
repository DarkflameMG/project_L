using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCatalogSys : MonoBehaviour
{
    [SerializeField]private GameObject catalogUI;
    [SerializeField]private RoomPreviewSO allRoom;
    [SerializeField]private Transform startRoomFlag;
    [SerializeField]private Transform saveMapSys;
    private Transform currentSlot;
    private Transform currentStartRoom;
    public void ShowUI(Transform slot)
    {
        catalogUI.SetActive(true);
        SetCurerntSlot(slot);
    }

    public void CloseUI()
    {
        catalogUI.SetActive(false);
    }

    private void SetCurerntSlot(Transform slot)
    {
        currentSlot = slot;
        catalogUI.GetComponent<RectTransform>().localPosition = slot.GetComponent<RectTransform>().localPosition + slot.parent.GetComponent<RectTransform>().localPosition + new Vector3(105f,0,0);
    }

    public void AddRoom(RoomType type)
    {
        if(type == RoomType.defalut)
        {
            currentSlot.GetComponent<RoomSlot>().SetRoomType(type,allRoom.defalut);
            ResetStartRoom();
        }
        else if(type == RoomType.room1)
        {
            currentSlot.GetComponent<RoomSlot>().SetRoomType(type,allRoom.room1);
        }
    }

    public void AddStartRoom()
    {
        if(currentStartRoom)
        {
            ResetStartRoom();
        }
        currentStartRoom = currentSlot;
        currentStartRoom.GetComponent<RoomSlot>().SetStartRoom(true);
        SetFlagPos();

        saveMapSys.GetComponent<SaveMapSys>().SetHaveStartRoom(true);
    }

    private void ResetStartRoom()
    {
        currentStartRoom.GetComponent<RoomSlot>().SetStartRoom(false);
        startRoomFlag.GetComponent<RectTransform>().localPosition = new Vector3(1247f,66f,0);
        
        saveMapSys.GetComponent<SaveMapSys>().SetHaveStartRoom(false);
    }

    private void SetFlagPos()
    {
        startRoomFlag.GetComponent<RectTransform>().localPosition = currentSlot.GetComponent<RectTransform>().localPosition + currentSlot.parent.GetComponent<RectTransform>().localPosition;
    }
}
