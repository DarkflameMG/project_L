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
    private FeatureType featureType = FeatureType.none;
    private Transform currentFlag;

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

    // public void SetStartRoom(bool isStartRoom)
    // {
    //     this.isStartRoom = isStartRoom;
    // }

    public void SetRoomFeature(FeatureType type,Transform flag,Transform flagPoint)
    {
        featureType = type;

        CreateFlag(flag,flagPoint);
    }

    private void CreateFlag(Transform flag,Transform flagPoint)
    {
        if(flag != null)
        {
            currentFlag = Instantiate(flag,flagPoint);
            currentFlag.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition + transform.parent.GetComponent<RectTransform>().localPosition;
        }
    }

    public void DestroyFlag()
    {
        if(currentFlag != null)
        {
            featureType = FeatureType.none;
            Destroy(currentFlag.gameObject);
        }
    }
}
