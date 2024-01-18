using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SetTableSys : MonoBehaviour
{
    [SerializeField]private MapSystem mapSystem;
    [SerializeField]private CuurentTruthTableSO tableSO;

    public void SetTable()
    {
        RoomDetail room = mapSystem.GetCurrentRoomDetail();
        ReadJson(File.ReadAllText(Application.streamingAssetsPath+"/TruthTable/"+room.puzzleName+".json"));
    }

    private void ReadJson(string json)
    {
        TruthTable table = JsonConvert.DeserializeObject<TruthTable>(json);
        // Debug.Log(tableSO.table);
        tableSO.table = table;
    }
}
