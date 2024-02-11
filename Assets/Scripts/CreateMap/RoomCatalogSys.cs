using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCatalogSys : MonoBehaviour
{
    [SerializeField]private GameObject catalogUI;
    [SerializeField]private RoomPreviewSO allRoom;
    [SerializeField]private FlagsMapSO allFlag;
    [SerializeField]private Transform flagPoint;
    [SerializeField]private Transform saveMapSys;
    [SerializeField]private DoorChoose doorChoose;
    private Transform currentSlot;
    private Transform currentStartRoom;
    private Transform currentExitRoom;
    public void ShowUI(Transform slot)
    {
        catalogUI.SetActive(true);
        SetCurerntSlot(slot);
        doorChoose.SetUp(currentSlot);
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
        if(type == RoomType.none)
        {
            currentSlot.GetComponent<RoomSlot>().SetRoomType(type,allRoom.defalut);
            currentSlot.GetComponent<RoomSlot>().DestroyFlag();
        }
        else if(type == RoomType.room1)
        {
            currentSlot.GetComponent<RoomSlot>().SetRoomType(type,allRoom.room1);
        }
    }

    public void AddRoomFeature(FeatureType type)
    {
        if(currentSlot.GetComponent<RoomSlot>().GetRoomType() != RoomType.none)
        {
            AddRoomFeature_Aux(type);
        }
    }

    private void AddRoomFeature_Aux(FeatureType type)
    {
        RoomSlot room = currentSlot.GetComponent<RoomSlot>();

        if(room.GetFeatureType() == FeatureType.start)
        {
            currentStartRoom = null;
        }
        else if(room.GetFeatureType() == FeatureType.exit)
        {
            currentExitRoom = null;
        }


        Transform flag = null;
        room.DestroyFlag();
        if(type == FeatureType.none)
        {
            // nothing happen
        }
        else if(type == FeatureType.monster)
        {

        }
        else if(type == FeatureType.puzzle)
        {
            flag = allFlag.puzzleFlag;
        }
        else if(type == FeatureType.start)
        {
            flag = allFlag.startFlag;
            if(currentStartRoom != null)
            {
                currentStartRoom.GetComponent<RoomSlot>().DestroyFlag();
            }
            currentStartRoom = currentSlot;
        }
        else if(type == FeatureType.exit)
        {
            flag = allFlag.exitFlag;
            if(currentExitRoom != null)
            {
                currentExitRoom.GetComponent<RoomSlot>().DestroyFlag();
            }
            currentExitRoom = currentSlot;
        }
        room.SetRoomFeature(type,flag,flagPoint);
    }

    public Transform GetStartRoom()
    {
        return currentStartRoom;
    }

    public Transform GetExitRoom()
    {
        return currentExitRoom;
    }

    public Transform GetCurrentSlot()
    {
        return currentSlot;
    }
}
