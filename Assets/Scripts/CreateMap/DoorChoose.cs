using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorChoose : MonoBehaviour
{
    [SerializeField]private GameObject key1;
    [SerializeField]private GameObject key2;
    [SerializeField]private GameObject key3;
    [SerializeField]private GameObject key4;
    [SerializeField]private TMP_Dropdown top;
    [SerializeField]private TMP_Dropdown down;
    [SerializeField]private TMP_Dropdown left;
    [SerializeField]private TMP_Dropdown right;
    [SerializeField]private GameObject topDoor;
    [SerializeField]private GameObject downDoor;
    [SerializeField]private GameObject leftDoor;
    [SerializeField]private GameObject rightDoor;
    private RoomSlotDoor doors;
    private void Awake() {
        top.onValueChanged.AddListener(delegate{UpdateDoorFeature(RoomSide.front,top.value);});
        down.onValueChanged.AddListener(delegate{UpdateDoorFeature(RoomSide.back,down.value);});
        left.onValueChanged.AddListener(delegate{UpdateDoorFeature(RoomSide.left,left.value);});
        right.onValueChanged.AddListener(delegate{UpdateDoorFeature(RoomSide.right,right.value);});
    }
    private void Update() {
        CheckDropdown();
        if(doors != null)
        {
            CheckDoors();
        }
    }

    private void ShowKeyTab(RoomSide side,bool showed)
    {
        if(side == RoomSide.front)
        {
            key1.SetActive(showed);
        }
        else if(side == RoomSide.back)
        {
            key2.SetActive(showed);
        }
        else if(side == RoomSide.left)
        {
            key3.SetActive(showed);
        }
        else if(side == RoomSide.right)
        {
            key4.SetActive(showed);
        }
    }

    private void SetHideTab(RoomSide side,bool data)
    {

        if(side == RoomSide.front)
        {
            topDoor.SetActive(data);
        }
        else if(side == RoomSide.back)
        {
            downDoor.SetActive(data);
        }
        else if(side == RoomSide.left)
        {
            leftDoor.SetActive(data);
        }
        else if(side == RoomSide.right)
        {
            rightDoor.SetActive(data);
        }

        if(!data)
        {
            ShowKeyTab(side,false);
        }
    }

    public void ShowAll()
    {
        topDoor.SetActive(true);
        downDoor.SetActive(true);
        leftDoor.SetActive(true);
        rightDoor.SetActive(true);
    }

    public void SetUp(Transform room)
    {
        doors = room.GetComponent<RoomSlotDoor>();
        UpdateDropDown();
    }

    private void CheckDoors()
    {
        bool[] bools = doors.GetActive();
        SetHideTab(RoomSide.front,bools[0]);
        SetHideTab(RoomSide.back,bools[1]);
        SetHideTab(RoomSide.left,bools[2]);
        SetHideTab(RoomSide.right,bools[3]);
    }

    private void CheckDropdown()
    {
        if(top.value == 1)
        {
            ShowKeyTab(RoomSide.front,true);
        }
        else if(top.value != 1)
        {
            ShowKeyTab(RoomSide.front,false);
        }

        if(down.value == 1)
        {
            ShowKeyTab(RoomSide.back,true);
        }
        else if(down.value != 1)
        {
            ShowKeyTab(RoomSide.back,false);
        }

        if(left.value == 1)
        {
            ShowKeyTab(RoomSide.left,true);
        }
        else if(left.value != 1)
        {
            ShowKeyTab(RoomSide.left,false);
        }

        if(right.value == 1)
        {
            ShowKeyTab(RoomSide.right,true);
        }
        else if(right.value != 1)
        {
            ShowKeyTab(RoomSide.right,false);
        }
    }

    public void UpdateDropDown()
    {
        int[] feature = doors.GetDoorFeature();
        top.SetValueWithoutNotify(feature[0]);
        down.SetValueWithoutNotify(feature[1]);
        left.SetValueWithoutNotify(feature[2]);
        right.SetValueWithoutNotify(feature[3]);
    }

    private void UpdateDoorFeature(RoomSide side,int value)
    {
        Debug.Log("UpdateDoors");
        doors.SetDoorFeature(side,value);
    }
}
