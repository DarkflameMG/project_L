using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSlotDoor : MonoBehaviour
{
    [SerializeField]private GameObject front;
    [SerializeField]private GameObject back;
    [SerializeField]private GameObject left;
    [SerializeField]private GameObject right;
    private bool[] doorsActive;
    private int[] doorsFeature;
    private Transform[] roomAround;
    AddDoorSys addDoorSys;
    private void Awake() {
        addDoorSys = GameObject.Find("AddDoorSys").GetComponent<AddDoorSys>();
        doorsActive = new bool[4];
        doorsFeature = new int[4];
    }

    public void ShowDoor(RoomSide side,bool activate)
    {
        if(side == RoomSide.front)
        {
            front.SetActive(activate);
            doorsActive[0] = activate;
        }
        else if(side == RoomSide.back)
        {
            back.SetActive(activate);
            doorsActive[1] = activate;
        }
        else if(side == RoomSide.left)
        {
            left.SetActive(activate);
            doorsActive[2] = activate;
        }
        else if(side == RoomSide.right)
        {
            right.SetActive(activate);
            doorsActive[3] = activate;
        }
    }

    private void HideOrShowDoor(RoomSide side,bool activate)
    {
        if(side == RoomSide.front)
        {
            front.SetActive(activate);
        }
        else if(side == RoomSide.back)
        {
            back.SetActive(activate);
        }
        else if(side == RoomSide.left)
        {
            left.SetActive(activate);
        }
        else if(side == RoomSide.right)
        {
            right.SetActive(activate);
        }
    }

    public void HideAllDoor()
    {
        front.SetActive(false);
        back.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        doorsActive[0] = false;
        doorsActive[1] = false;
        doorsActive[2] = false;
        doorsActive[3] = false;
    }

    public bool[] GetActive()
    {
        return doorsActive;
    }

    public int[] GetDoorFeature()
    {
        return doorsFeature;
    }

    public void SetDoorFeature(RoomSide side,int value)
    {
        roomAround = GetComponent<RoomSlot>().GetRoomAround();
        Debug.Log(roomAround.Length);
        if(side == RoomSide.front)
        {
            doorsFeature[0] = value;
            if(roomAround[0] != null)
            {
                roomAround[0].GetComponent<RoomSlotDoor>().SetDoorFeature(RoomSide.back,value);
            }
        }
        else if(side == RoomSide.back)
        {
            doorsFeature[1] = value;
            if(roomAround[1] != null)
            {
                roomAround[1].GetComponent<RoomSlotDoor>().SetDoorFeature(RoomSide.front,value);
            }
        }
        else if(side == RoomSide.left)
        {
            doorsFeature[2] = value;
            if(roomAround[2] != null)
            {
                roomAround[2].GetComponent<RoomSlotDoor>().SetDoorFeature(RoomSide.right,value);   
            }
        }
        else if(side == RoomSide.right)
        {
            doorsFeature[3] = value;
            if(roomAround[3] != null)
            {
                roomAround[3].GetComponent<RoomSlotDoor>().SetDoorFeature(RoomSide.left,value);
            }  
        }

        DoorColor(side,value);
    }

    private void DoorColor(RoomSide side,int value)
    {
        if(value == 0)
        {
            HideOrShowDoor(side,true);
        }
        else if(value == 1)
        {
            HideOrShowDoor(side,true);
        }
        else if(value == 2)
        {
            HideOrShowDoor(side,false);
        }
    }
}
