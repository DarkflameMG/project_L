using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoomSlot : MonoBehaviour,IPointerClickHandler
{
    private int x,y;
    private RoomCatalogSys roomCatalogSys;
    private RoomType roomType = RoomType.defalut;
    private bool isStartRoom;

    private void Awake() {
        roomCatalogSys = GameObject.Find("RoomCatalogSys").GetComponent<RoomCatalogSys>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(x+" "+y);
        Debug.Log(GetComponent<RectTransform>().localPosition);
        roomCatalogSys.ShowUI(this.transform);
    }

    public void SetXY(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetRoomType(RoomType type,Sprite roomPreview)
    {
        roomType = type;
        transform.GetChild(0).GetComponent<Image>().sprite = roomPreview;
    }

    public void SetStartRoom(bool isStartRoom)
    {
        this.isStartRoom = isStartRoom;
    }
}
