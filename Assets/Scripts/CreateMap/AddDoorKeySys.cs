using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddDoorKeySys : MonoBehaviour
{
    [SerializeField]private TMP_Text keyTop;
    [SerializeField]private TMP_Text keyDown;
    [SerializeField]private TMP_Text keyLeft;
    [SerializeField]private TMP_Text keyRight;
    [SerializeField]private TMP_Text currentDoor;
    [SerializeField]private GameObject keyListUI;
    [SerializeField]private RoomCatalogSys roomCatalogSys;
    private string template = "Door side : ";
    private RoomSide currentSide;

    private void Update() {
        SetCurrentKey();
    }

    public void OpenKeyList(RoomSide side)
    {
        currentSide = side;
        keyListUI.SetActive(true);
        if(side == RoomSide.front)
        {
            currentDoor.text = template+"Top";
        }
        else if(side == RoomSide.back)
        {
            currentDoor.text = template+"Down";
        }
        else if(side == RoomSide.left)
        {
            currentDoor.text = template+"Left";
        }
        else if(side == RoomSide.right)
        {
            currentDoor.text = template+"Right";
        }
    }

    public void SetDoorKey(string name)
    {
        RoomSlotDoor room = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlotDoor>();
        room.SetDoorKey(currentSide,name);
        keyListUI.SetActive(false);
    }

    private void SetCurrentKey()
    {
        Transform currentRoom = roomCatalogSys.GetCurrentSlot();
        if(currentRoom != null)
        {
            RoomSlotDoor room = currentRoom.GetComponent<RoomSlotDoor>();
            string[] key = room.GetKey();
            string[] initKey = new string[4];
            for(int i=0 ;i<4;i++)
            {
                initKey[i] = "none";
                if(key[i] != "")
                {
                    initKey[i] = key[i];
                }
            }
            keyTop.text = initKey[0];
            keyDown.text = initKey[1];
            keyLeft.text = initKey[2];
            keyRight.text = initKey[3];
        }
    }
}
