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

    private Transform currentRoom;
    private Transform mapspawn;
    private Transform[] roomObj;
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

    public void SetStartRoom(Transform room,Transform spawnLoc)
    {
        currentRoom = room;
        mapspawn = spawnLoc;
    }

    public void ChangeRoom(RoomSide side)
    {
        StartCoroutine(TransitionRoom(side));
       
    }

    private void SpawnObjs()
    {
        foreach(RoomDetail room in rooms)
        {
            if(room.x == mapLoc.current_x && room.y == mapLoc.current_y && room.objs != null)
            {
                SpawnRoom(room);
                foreach(Objs obj in room.objs)
                {
                    roomObj = new Transform[room.objs.Length];
                    int i = 0;
                    if(obj.type.Equals("puzzle"))
                    {
                        Transform puzzle = Instantiate(allObj.puzzle,currentRoom);
                        puzzle.localPosition = new Vector3 (obj.posx,obj.posy,obj.posz);
                        roomObj[i] = puzzle;
                        i++;
                    }
                    else if(obj.type.Equals("boss1"))
                    {
                        Transform boss = Instantiate(allObj.boss1,currentRoom);
                        boss.localPosition = new Vector3 (obj.posx,obj.posy,obj.posz);
                        roomObj[i] = boss;
                        i++;
                    }
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

         mapInfo.Busy = false;
        // Debug.Log(currentRoom);
        player.position = Vector3.zero;
        DestroyRoom();
        // SpawnRoom();
        SpawnObjs();

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

    private void SpawnRoom(RoomDetail room)
    {
        if(room.roomType == RoomType.room1)
        {
            currentRoom = Instantiate(allRoom.room1,mapspawn);
        }
    }
}
