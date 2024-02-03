using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSlotDoor : MonoBehaviour
{
    [SerializeField]private GameObject front;
    [SerializeField]private GameObject back;
    [SerializeField]private GameObject left;
    [SerializeField]private GameObject right;

    AddDoorSys addDoorSys;
    private void Awake() {
        addDoorSys = GameObject.Find("AddDoorSys").GetComponent<AddDoorSys>();
    }

    public void ShowDoor(RoomSide side,bool activate)
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
}
