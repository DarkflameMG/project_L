using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoomSlot : MonoBehaviour,IPointerClickHandler
{
    private int x,y;
    private RoomCatalogSys roomCatalogSys;
    private RoomType roomType = RoomType.none;
    private FeatureType featureType = FeatureType.none;
    private Transform currentFlag;
    private LogicGateConfig config;
    private string curretPuzzleName = "none";
    private AddDoorSys addDoorSys;

    private void Awake() {
        config = new();
        if(GameObject.Find("RoomCatalogSys") != null)
        {
            roomCatalogSys = GameObject.Find("RoomCatalogSys").GetComponent<RoomCatalogSys>();
        }

        if(GameObject.Find("AddDoorSys") != null)
        {
            addDoorSys = GameObject.Find("AddDoorSys").GetComponent<AddDoorSys>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log(x+" "+y);
        // Debug.Log(GetComponent<RectTransform>().localPosition);
        if(roomCatalogSys != null)
        {
            roomCatalogSys.ShowUI(this.transform);
        }
    }

    public void SetXY(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    public int[] GetXY()
    {
        int[] pair = new int[2];
        pair[0] = x;
        pair[1] = y;
        return pair;
    }

    public void SetRoomType(RoomType type,Sprite roomPreview)
    {
        roomType = type;
        transform.GetChild(0).GetComponent<Image>().sprite = roomPreview;
        bool activated = true;
        if(type == RoomType.none)
        {
            activated = false;
        }
        addDoorSys.SetDoorAround(transform,activated);
    }

    public RoomType GetRoomType()
    {
        return roomType;
    }

    public void SetRoomFeature(FeatureType type,Transform flag,Transform flagPoint)
    {
        featureType = type;

        CreateFlag(flag,flagPoint);
    }

    public FeatureType GetFeatureType()
    {
        return featureType;
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

    public void SetCurrentPuzzle(string puzzleName)
    {
        curretPuzzleName = puzzleName;
    }

    public string GetPuzzleName()
    {
        return curretPuzzleName;
    }

    public void SetConfig(LogicGateConfig data)
    {
        config = data;
    }
    public LogicGateConfig GetConfig()
    {
        return config;
    }
}
