using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnum : MonoBehaviour
{
    
}

public enum SlotNo{s1,s2,output};

public enum QuestType{ none,hunt,arena,investigate }
public enum Page{none,main,selectType,questList,custom,mainUp,up,mod}

public enum Stat{atk,def,spd,hp,sp}

public enum RoomSide{front,back,left,right}
public enum GateType{not,and,or,batterry,bulb}
public enum RoomType{defalut,room1}


[System.Serializable]
public class SaveGate
{
    public string gateName;
    public float posx;
    public float posy;
    public float posz;
}

[System.Serializable]
public class MissionInfo
{
    public string missionName;
    public SaveGate[] saveGates;
    public Lines[] lines;
    public Rewards reward;
    public string detail;
    public MapInfo map;
}

[System.Serializable]
public class Lines
{
   public float pos1X;
   public float pos2X;
   public float pos1Y;
   public float pos2Y;
   public string c1Name;
   public SlotNo c1Type;
   public string c2Name;
   public SlotNo c2Type;
}

[System.Serializable]
public class Rewards
{

}

[System.Serializable]
public class PuzzleInfo
{
    public string puzzleName;
    public SaveGate[] saveGates;
}

[System.Serializable]
public class MapInfo
{
    public int wide;
    public int high;
    public int[] startPoint;
    public RoomDetail[] rooms;
}

[System.Serializable]
public class RoomDetail
{
    public int x;
    public int y;
    public string type;
    public Objs[] objs;
}

[System.Serializable]
public class Objs
{
    public float posx;
    public float posy;
    public float posz;
    public string type;
    public string puzzleName;
}