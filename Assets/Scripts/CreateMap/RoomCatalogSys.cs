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
            currentSlot.GetComponent<RoomSlot>().DestroyFlag();
        }
        else if(type == RoomType.room1)
        {
            currentSlot.GetComponent<RoomSlot>().SetRoomType(type,allRoom.room1);
        }
    }

    public void AddRoomFeature(FeatureType type)
    {
        Transform flag = null;
        currentSlot.GetComponent<RoomSlot>().DestroyFlag();
        if(type == FeatureType.none)
        {

        }
        else if(type == FeatureType.monster)
        {

        }
        else if(type == FeatureType.boss)
        {

        }
        else if(type == FeatureType.puzzle)
        {

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
        currentSlot.GetComponent<RoomSlot>().SetRoomFeature(type,flag,flagPoint);
    }

}
