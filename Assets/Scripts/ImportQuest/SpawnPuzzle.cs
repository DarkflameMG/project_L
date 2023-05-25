using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPuzzle : MonoBehaviour
{
    [SerializeField]private GatesPrefabSO allGate;
    private MissionInfo puzzle;
    public void setData(MissionInfo data)
    {
        puzzle = data;
    }

    public void StartPuzzle()
    {
        
    }
}
