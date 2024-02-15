using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMenagement : MonoBehaviour
{
    [SerializeField]private Transform doors;
    private Doors doorFront;
    private Doors doorBack;
    private Doors doorLeft;
    private Doors doorRight;
    private void Awake() 
    {
        doorFront = doors.Find("front").GetComponent<Doors>();
        doorBack = doors.Find("back").GetComponent<Doors>();
        doorLeft = doors.Find("left").GetComponent<Doors>();
        doorRight = doors.Find("right").GetComponent<Doors>();

        // CheckDoor();
        // HideDoor();
    }

    // private void CheckDoor()
    // {
    //     front = !doorFront.CantInteract();
    //     back = !doorBack.CantInteract();
    //     left = !doorLeft.CantInteract();
    //     right = !doorRight.CantInteract();
    // }

    // public void HideDoor()
    // {
    //     doorFront.gameObject.SetActive(front);
    //     doorBack.gameObject.SetActive(back);
    //     doorLeft.gameObject.SetActive(left);
    //     doorRight.gameObject.SetActive(right);
    // }

    public void SetRoomDoor(RoomSide side,DoorState state,string key)
    {
        if(side == RoomSide.front)
        {
            SetDoorState(doorFront,state,key);
        }
        else if(side == RoomSide.back)
        {
            SetDoorState(doorBack,state,key);
        }
        else if(side == RoomSide.left)
        {
            SetDoorState(doorLeft,state,key);
        }
        else if(side == RoomSide.right)
        {
            SetDoorState(doorRight,state,key);
        }
    }

    private void SetDoorState(Doors doors,DoorState state,string key)
    {
        if(state == DoorState.unlocked)
        {
            //nothing to do
        }
        else if(state == DoorState.locked)
        {
            doors.SetLocked(true,key);
        }
        else if(state == DoorState.hide)
        {
            doors.gameObject.SetActive(false);
        }
    }
}
