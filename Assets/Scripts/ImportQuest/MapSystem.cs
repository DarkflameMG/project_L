using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    private Transform currentRoom;
    private RoomDetail currentRoomDetail;
    private Transform mapspawn;
    // private Transform[] roomObj;
    private RoomDetail[] rooms;

    private void Start() {
        player.position = Vector3.zero;
    }
    private void Update() {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Lobby");
        }
    }
    public void SetStartLoc(int x,int y,int width,int hight)
    {
        mapLoc.current_x = x;
        mapLoc.current_y = y;
        mapLoc.width = width;
        mapLoc.hight = hight;
        rooms = missionSO.missionInfo.rooms;
    }

    public void SetStartRoom(Transform room,Transform spawnLoc)
    {
        currentRoom = room;
        mapspawn = spawnLoc;
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
                // foreach(Objs obj in room.objs)
                // {
                //     roomObj = new Transform[room.objs.Length];
                //     int i = 0;
                //     if(obj.type.Equals("puzzle"))
                //     {
                //         Transform puzzle = Instantiate(allObj.puzzle,currentRoom);
                //         puzzle.localPosition = new Vector3 (obj.posx,obj.posy,obj.posz);
                //         roomObj[i] = puzzle;
                //         i++;
                //     }
                //     else if(obj.type.Equals("boss1"))
                //     {
                //         Transform boss = Instantiate(allObj.boss1,currentRoom);
                //         boss.localPosition = new Vector3 (obj.posx,obj.posy,obj.posz);
                //         roomObj[i] = boss;
                //         i++;
                //     }
                // }
                if(room.Ftype == FeatureType.puzzle)
                {
                    Transform puzzle = Instantiate(allObj.puzzle,currentRoom);
                    puzzle.localPosition = Vector3.zero;
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
}
