using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSlotDoor : MonoBehaviour
{
    [SerializeField]private GameObject front;
    [SerializeField]private GameObject back;
    [SerializeField]private GameObject left;
    [SerializeField]private GameObject right;
    private bool[] doorsActive;
    private int[] doorsFeature;
    private string[] key;
    private Color green = new Color32(64,255,0,255);
    private Color red = new Color32(255,144,0,255);
    private Transform[] roomAround;
    AddDoorSys addDoorSys;
    private void Awake() {
        addDoorSys = GameObject.Find("AddDoorSys").GetComponent<AddDoorSys>();
        roomAround = new Transform[4];
        doorsActive = new bool[4];
        doorsFeature = new int[4];
        key = new string[4];
        key[0] = "";
        key[1] = "";
        key[2] = "";
        key[3] = "";
    }
    public void SetRoomAround(Transform[] rooms)
    {
        roomAround = rooms;
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
        // roomAround = GetComponent<RoomSlot>().GetRoomAround();
        if(side == RoomSide.front)
        {
            doorsFeature[0] = value;
            if(roomAround[0] != null)
            {
                roomAround[0].GetComponent<RoomSlotDoor>().SetOtherDoorFeature(RoomSide.back,value);
            }
        }
        else if(side == RoomSide.back)
        {
            doorsFeature[1] = value;
            if(roomAround[1] != null)
            {
                roomAround[1].GetComponent<RoomSlotDoor>().SetOtherDoorFeature(RoomSide.front,value);
            }
        }
        else if(side == RoomSide.left)
        {
            doorsFeature[2] = value;
            if(roomAround[2] != null)
            {
                roomAround[2].GetComponent<RoomSlotDoor>().SetOtherDoorFeature(RoomSide.right,value);   
            }
        }
        else if(side == RoomSide.right)
        {
            doorsFeature[3] = value;
            if(roomAround[3] != null)
            {
                roomAround[3].GetComponent<RoomSlotDoor>().SetOtherDoorFeature(RoomSide.left,value);
            }  
        }

        DoorColor(side,value);
    }

    public void SetOtherDoorFeature(RoomSide side,int value)
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

        DoorColor(side,value);
    }

    private void DoorColor(RoomSide side,int value)
    {
        bool isLocked = false;
        if(value == 0)
        {
            HideOrShowDoor(side,true);
            SetDoorKey(side,"");
        }
        else if(value == 1)
        {
            HideOrShowDoor(side,true);
            isLocked = true;
        }
        else if(value == 2)
        {
            HideOrShowDoor(side,false);
            SetDoorKey(side,"");
        }
        ChangeColor(side,isLocked);
    }

    private void ChangeColor(RoomSide side,bool isLocked)
    {
        Color newColor = green;
        if(isLocked)
        {
            newColor = red;
        }

        if(side == RoomSide.front)
        {
            front.GetComponent<Image>().color = newColor;
        }
        else if(side == RoomSide.back)
        {
            back.GetComponent<Image>().color = newColor;
        }
        else if(side == RoomSide.left)
        {
            left.GetComponent<Image>().color = newColor;
        }
        else if(side == RoomSide.right)
        {
            right.GetComponent<Image>().color = newColor;
        }
    }

    public void SetDoorKey(RoomSide side, string name)
    {
        // Debug.Log("Set "+side+" name "+name);
        if(side == RoomSide.front)
        {
            key[0] = name;
            if(roomAround[0] != null)
            {
                roomAround[0].GetComponent<RoomSlotDoor>().SetOtherDoorKey(RoomSide.back,name);
            }
            else
                Debug.Log("Other null");
        }
        else if(side == RoomSide.back)
        {
            key[1] = name;
            if(roomAround[1] != null)
            {
                roomAround[1].GetComponent<RoomSlotDoor>().SetOtherDoorKey(RoomSide.front,name);
            }
            else
                Debug.Log("Other null");
        }
        else if(side == RoomSide.left)
        {
            key[2] = name;
            if(roomAround[2] != null)
            {
                roomAround[2].GetComponent<RoomSlotDoor>().SetOtherDoorKey(RoomSide.right,name);
            }
            else
                Debug.Log("Other null");
        }
        else if(side == RoomSide.right)
        {
            key[3] = name;
            if(roomAround[3] != null)
            {
                roomAround[3].GetComponent<RoomSlotDoor>().SetOtherDoorKey(RoomSide.left,name);
            }
            else
                Debug.Log("Other null");
        }
    }
    public void SetOtherDoorKey(RoomSide side, string name)
    {
        // Debug.Log("Set other "+side+" name "+name);
        if(side == RoomSide.front)
        {
            key[0] = name;
        }
        else if(side == RoomSide.back)
        {
            key[1] = name;
        }
        else if(side == RoomSide.left)
        {
            key[2] = name;
        }
        else if(side == RoomSide.right)
        {
            key[3] = name;
        }
    }
    public string[] GetKey()
    {
        return key;
    }
}
