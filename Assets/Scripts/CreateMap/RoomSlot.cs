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
    private Transform[] roomAround;
    private MonsterDetail monster;
    private MonsterDetailSys monsterDetailSys;

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
        if(GameObject.Find("MonsterDetailSys") != null)
        {
            monsterDetailSys = GameObject.Find("MonsterDetailSys").GetComponent<MonsterDetailSys>();
            monster = new()
            {
                name = "",
                hp = 0,
                atk = 0,
                rewards = new()
            };
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log(x+" "+y);
        // Debug.Log(GetComponent<RectTransform>().localPosition);
        if(roomCatalogSys != null)
        {
            roomCatalogSys.ShowUI(this.transform);
            addDoorSys.CloseKeyUI();
            monsterDetailSys.SetMonDetail();
            // Debug.Log("front:"+(roomAround[0]!=null)+"   back:"+(roomAround[1]!=null)+"   left:"+(roomAround[2]!=null)+"   right:"+(roomAround[3]!=null));
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
        // roomAround = addDoorSys.GetRoomAround();
    }

    public void SetRoomAround()
    {
        addDoorSys.SetDoorAround(transform,false);
        roomAround = addDoorSys.GetRoomAround();
        GetComponent<RoomSlotDoor>().SetRoomAround(roomAround);
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
            if(featureType == FeatureType.puzzle || featureType == FeatureType.exit)
            {
                currentFlag.GetComponent<PuzzleFlag>().SetRoomSlot(this);
            }
        }
    }

    public void DestroyFlag()
    {
        if(currentFlag != null)
        {
            if(featureType == FeatureType.puzzle || featureType == FeatureType.exit)
            {
                currentFlag.GetComponent<PuzzleFlag>().SetRoomSlot(null);
            }
            curretPuzzleName = "none";
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

    public Transform[] GetRoomAround()
    {
        return roomAround;
    }

    public void SetCurrentMon(MonsterDetail detail)
    {
        monster = detail;
    }

    public MonsterDetail GetCurrentMon()
    {
        return monster;
    }
}
