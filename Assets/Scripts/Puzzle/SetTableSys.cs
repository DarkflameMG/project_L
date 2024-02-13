using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SetTableSys : MonoBehaviour
{
    [SerializeField]private MapSystem mapSystem;
    [SerializeField]private CuurentTruthTableSO tableSO;
    [SerializeField]private FinalPuzzleCheck finalCheck;

    public void SetTable()
    {
        RoomDetail room = mapSystem.GetCurrentRoomDetail();
        tableSO.tableName = room.puzzleName;
        finalCheck.SetTable();
    }
}
