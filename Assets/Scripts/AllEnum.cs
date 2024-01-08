using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnum : MonoBehaviour
{
    
}

public enum SlotNo{s1,s2,output};

public enum QuestType{ none,hunt,arena,investigate }
public enum Page{none,main,selectType,questList,custom,mainUp,up,mod}

public enum RoomSide{front,back,left,right}
public enum GateType{not,and,or,batterry,bulb}
public enum RoomType{none,room1}
public enum FeatureType{none,monster,boss,puzzle,start,exit}
public enum CreateMapCatalog{floor,feature,puzzle}
public enum MenuBtn{lobby,map,puzzle,none}


[System.Serializable]
public class SaveGate
{
    public string gateName;
    public float posx;
    public float posy;
    public float posz;
}

[System.Serializable]
public class PuzzleInfo
{
    public string PuzzleName;
    public SaveGate[] saveGates;
    public Lines[] lines;
    // public MapInfo map;
}

[System.Serializable]
public class MissionInfo
{
    public string MissionName;
    public int width;
    public int hight;
    public int[] startPos;
    public RoomDetail[] rooms;
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
   public bool expectBool;
}

// [System.Serializable]
// public class Rewards
// {

// }

// [System.Serializable]
// public class PuzzleInfo
// {
//     public string puzzleName;
//     public SaveGate[] saveGates;
// }

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
    public FeatureType Ftype;
    public RoomType roomType;
    public string puzzleName;
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

[System.Serializable]
public class TruthTable
{
   public int[] X1;
   public int[] X2;
   public int[] X3;
   public int[] X4;
   public int[] Y1;
   public int[] Y2;
   public int[] Y3;
   public int[] Y4;
}