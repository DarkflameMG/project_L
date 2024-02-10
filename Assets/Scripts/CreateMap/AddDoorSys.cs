using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDoorSys : MonoBehaviour
{
    [SerializeField]private Transform slots;
    private bool activated;
    private Transform[] roomAround;
    private void Awake() {
        roomAround = new Transform[4];
    }
    public void SetDoorAround(Transform currentRoom,bool show)
    {
        activated = show;
        //same row
        LeftSide(currentRoom,activated);
        RightSide(currentRoom,activated);

        //upper row
        FrontSide(currentRoom,activated);

        //lower row
        BackSide(currentRoom,activated);
    }

    private void SetDoor(RoomSlotDoor room1,RoomSlotDoor room2,RoomSide room1Side,RoomSide room2Side,RoomType type,bool activated)
    {
        if(type != RoomType.none)
        {
            room1.ShowDoor(room1Side,activated);
            room2.ShowDoor(room2Side,activated);
        }
    }

    public void LeftSide(Transform currentRoom,bool activated)
    {
        RoomSlot roomSlot = currentRoom.GetComponent<RoomSlot>();
        RoomSlotDoor roomSlotDoor = currentRoom.GetComponent<RoomSlotDoor>();
        int x = roomSlot.GetXY()[0],y = roomSlot.GetXY()[1];
        Transform line1 = slots.GetChild(y);
        if(x-1 >= 0)
        {
            Transform leftRoom = line1.GetChild(x-1);
            roomAround[2] = leftRoom;
            RoomSlot leftRoomSlot = leftRoom.GetComponent<RoomSlot>();
            RoomSlotDoor lr = leftRoom.GetComponent<RoomSlotDoor>();
            SetDoor(roomSlotDoor,lr,RoomSide.left,RoomSide.right,leftRoomSlot.GetRoomType(),activated);
        }
    }

    public void RightSide(Transform currentRoom,bool activate)
    {
        RoomSlot roomSlot = currentRoom.GetComponent<RoomSlot>();
        RoomSlotDoor roomSlotDoor = currentRoom.GetComponent<RoomSlotDoor>();
        int x = roomSlot.GetXY()[0],y = roomSlot.GetXY()[1];
        Transform line1 = slots.GetChild(y);
        int columnCount = line1.childCount;
        if(x+1 < columnCount)
        {
            Transform rightRoom = line1.GetChild(x+1);
            roomAround[3] = rightRoom;
            RoomSlot rightRoomSlot = rightRoom.GetComponent<RoomSlot>();
            RoomSlotDoor rr = rightRoom.GetComponent<RoomSlotDoor>();
            SetDoor(roomSlotDoor,rr,RoomSide.right,RoomSide.left,rightRoomSlot.GetRoomType(),activated);
        }
    }

    public void FrontSide(Transform currentRoom,bool activate)
    {
        RoomSlot roomSlot = currentRoom.GetComponent<RoomSlot>();
        RoomSlotDoor roomSlotDoor = currentRoom.GetComponent<RoomSlotDoor>();
        int x = roomSlot.GetXY()[0],y = roomSlot.GetXY()[1];
        Transform line0;
        if(y-1 >= 0)
        {
            line0 = slots.GetChild(y-1);
            Transform upRoom = line0.GetChild(x);
            roomAround[0] = upRoom;
            RoomSlot upRoomSlot = upRoom.GetComponent<RoomSlot>();
            RoomSlotDoor ur = upRoom.GetComponent<RoomSlotDoor>();
            SetDoor(roomSlotDoor,ur,RoomSide.front,RoomSide.back,upRoomSlot.GetRoomType(),activated);
        }
    }

    public void BackSide(Transform currentRoom,bool activate)
    {
        RoomSlot roomSlot = currentRoom.GetComponent<RoomSlot>();
        RoomSlotDoor roomSlotDoor = currentRoom.GetComponent<RoomSlotDoor>();
        int slotsChildCount = slots.childCount;
        int x = roomSlot.GetXY()[0],y = roomSlot.GetXY()[1];
        Transform line2;
        if(y+1 < slotsChildCount)
        {
            line2 = slots.GetChild(y+1);
            Transform downRoom = line2.GetChild(x);
            roomAround[1] = downRoom;
            RoomSlot downRoomSlot = downRoom.GetComponent<RoomSlot>();
            RoomSlotDoor dr = downRoom.GetComponent<RoomSlotDoor>();
            SetDoor(roomSlotDoor,dr,RoomSide.back,RoomSide.front,downRoomSlot.GetRoomType(),activated);
        }
    }

    public Transform[] GetRoomAround()
    {
        return roomAround;
    }
}
