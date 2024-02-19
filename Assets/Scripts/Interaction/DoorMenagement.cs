using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMenagement : MonoBehaviour
{
    [SerializeField]private Transform doors;
    [SerializeField]private Transform walls;
    private Doors doorFront;
    private Doors doorBack;
    private Doors doorLeft;
    private Doors doorRight;

    private GameObject fWall_1;
    private GameObject bWall_1;
    private GameObject lWall_1;
    private GameObject rWall_1;

    private GameObject fWall_2;
    private GameObject bWall_2;
    private GameObject lWall_2;
    private GameObject rWall_2;
    private void Awake() 
    {
        doorFront = doors.Find("doorFront").GetComponent<Doors>();
        doorBack = doors.Find("doorBack").GetComponent<Doors>();
        doorLeft = doors.Find("doorLeft").GetComponent<Doors>();
        doorRight = doors.Find("doorRight").GetComponent<Doors>();

        fWall_1 = walls.Find("frontWall").gameObject;
        bWall_1 = walls.Find("backWall").gameObject;
        lWall_1 = walls.Find("leftWall").gameObject;
        rWall_1 = walls.Find("rightWall").gameObject;

        fWall_2 = walls.Find("frontWallV2").gameObject;
        bWall_2 = walls.Find("backWallV2").gameObject;
        lWall_2 = walls.Find("leftWallV2").gameObject;
        rWall_2 = walls.Find("rightWallV2").gameObject;
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
            SetDoorState(doorFront,state,key,side);
        }
        else if(side == RoomSide.back)
        {
            SetDoorState(doorBack,state,key,side);
        }
        else if(side == RoomSide.left)
        {
            SetDoorState(doorLeft,state,key,side);
        }
        else if(side == RoomSide.right)
        {
            SetDoorState(doorRight,state,key,side);
        }
    }

    private void SetDoorState(Doors doors,DoorState state,string key,RoomSide side)
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
            if(side == RoomSide.front)
            {
                ChangeWall(fWall_1,fWall_2);
            }
            else if(side == RoomSide.back)
            {
                ChangeWall(bWall_1,bWall_2);
            }
            else if(side == RoomSide.left)
            {
                ChangeWall(lWall_1,lWall_2);
            }
            else if(side == RoomSide.right)
            {
                ChangeWall(rWall_1,rWall_2);
            }
        }
    }

    private void ChangeWall(GameObject v1,GameObject v2)
    {
        v1.SetActive(false);
        v2.SetActive(true);
    }
}
