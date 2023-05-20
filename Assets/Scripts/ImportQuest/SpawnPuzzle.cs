using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPuzzle : MonoBehaviour
{
    [SerializeField]private GatesPrefabSO allGate;
    private SaveGates puzzle;
    public void setData(SaveGates data)
    {
        puzzle = data;
    }

    public void StartPuzzle()
    {
        
    }
}
