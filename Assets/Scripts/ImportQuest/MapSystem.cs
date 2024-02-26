using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    [SerializeField]MapLocSO mapLoc;
    [SerializeField]LobbyInfo mapInfo;
    [SerializeField]RoomsSO allRoom;
    [SerializeField]Transform player;
    [SerializeField]MissionSO missionSO;
    [SerializeField]ObjectSO allObj;
    [SerializeField]GameObject levelLoader;
    [SerializeField]MiniMapSys miniMapSys;
    [SerializeField]AllLockedDoor allLockedDoor;
    [SerializeField]KeySO keySO;

    private Transform currentRoom;
    private RoomDetail currentRoomDetail;
    private Transform mapspawn;
    // private Transform[] roomObj;
    private RoomDetail[] rooms;

    private void Start() {
        player.position = Vector3.zero;
    }
    public void SetStartLoc(int x,int y,int width,int hight)
    {
        mapLoc.current_x = x;
        mapLoc.current_y = y;
        mapLoc.width = width;
        mapLoc.hight = hight;
        rooms = missionSO.missionInfo.rooms;
    }

    public void SetStartRoom(Transform spawnLoc)
    {
        mapspawn = spawnLoc;
        SpawnRoom();
    }

    public void ChangeRoom(RoomSide side)
    {
        StartCoroutine(TransitionRoom(side));
       
    }

    private void SpawnRoom()
    {
        foreach(RoomDetail room in rooms)
        {
            if(room.x == mapLoc.current_x && room.y == mapLoc.current_y && room.objs != null)
            {
                currentRoomDetail = room;
                SpawnFloor(room);

                SetRoomDoor(room);

                if(room.Ftype == FeatureType.puzzle)
                {
                    Transform puzzle = Instantiate(allObj.puzzle,currentRoom);
                    puzzle.localPosition = Vector3.zero;
                    if(keySO.currentKeys.Contains(room.puzzleName))
                    {
                        PuzzleBox puzzleBox = puzzle.Find("chest").GetComponent<PuzzleBox>();
                        puzzleBox.SetInteract(false);
                    }
                }
                else if(room.Ftype == FeatureType.exit)
                {
                    Transform puzzle = Instantiate(allObj.finalPuzzle,currentRoom);
                    puzzle.localPosition = Vector3.zero;
                }
                else if(room.Ftype == FeatureType.monster)
                {
                    Transform mon = Instantiate(allObj.monster,currentRoom);
                    mon.localPosition = Vector3.zero;
                }

                break;
            }
        }
    }

    private void DestroyRoom()
    {
        Destroy(currentRoom.gameObject);
        
    }

    IEnumerator TransitionRoom(RoomSide side)
    {
        mapInfo.Busy = true;
        levelLoader.GetComponent<LevelLoader>().GetAnimator().SetTrigger("Start");
        yield return new WaitForSeconds(1);
        levelLoader.GetComponent<LevelLoader>().GetAnimator().SetTrigger("End");

        miniMapSys.SetCurrentRoom("Room"+mapLoc.current_x+"_"+mapLoc.current_y);

        mapInfo.Busy = false;
        // Debug.Log(currentRoom);
        player.position = Vector3.zero;
        DestroyRoom();
        SpawnRoom();

        if(side == RoomSide.right)
        {
            player.position = new Vector3 (-6.4f,0,0);
        }
        else if(side == RoomSide.left)
        {
            player.position = new Vector3 (6.4f,0,0);
        }
        else if(side == RoomSide.back)
        {
            player.position = new Vector3 (0,0,6.4f);
        }
        else if(side == RoomSide.front)
        {
            player.position = new Vector3 (0,0,-7.4f);
        }
    }

    private void SpawnFloor(RoomDetail room)
    {
        if(room.roomType == RoomType.room1)
        {
            currentRoom = Instantiate(allRoom.room1,mapspawn);
        }
    }

    public RoomDetail GetCurrentRoomDetail()
    {
        return currentRoomDetail;
    }

    public void SetRoomDoor(RoomDetail room)
    {
        DoorMenagement doorMenagement = currentRoom.GetComponent<DoorMenagement>();
        DoorsDetail doorsDetail = room.doors;
        doorMenagement.SetRoomDoor(RoomSide.front,doorsDetail.front,doorsDetail.frontKey);
        doorMenagement.SetRoomDoor(RoomSide.back,doorsDetail.back,doorsDetail.backKey);
        doorMenagement.SetRoomDoor(RoomSide.left,doorsDetail.left,doorsDetail.leftKey);
        doorMenagement.SetRoomDoor(RoomSide.right,doorsDetail.right,doorsDetail.rightKey);
    }
}
