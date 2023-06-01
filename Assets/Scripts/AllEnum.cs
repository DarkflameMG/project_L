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
    public int map;
    public Rewards reward;
    public string detail;
}

[System.Serializable]
public class Rewards
{

}

[System.Serializable]
public class UpgradeForm
{

}