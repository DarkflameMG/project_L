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

    public void SetDoorLocked(RoomSide side,bool locked)
    {
        if(locked)
        {

        }
        else
        {

        }
    }

    public bool[] GetActive()
    {
        return doorsActive;
    }

    private void SetDoorFeature(RoomSide side,int value)
    {
        if(side == RoomSide.front)
        {
            doorsFeature[0] = value;
        }
        else if(side == RoomSide.back)
        {
            doorsFeature[1] = value;
        }
        else if(side == RoomSide.left)
        {
            doorsFeature[2] = value;
        }
        else if(side == RoomSide.right)
        {
            doorsFeature[3] = value;
        }
    }
}
