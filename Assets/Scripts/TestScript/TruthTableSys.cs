using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class TruthTableSys : MonoBehaviour
{
    [SerializeField]private Transform cellPrefab;
    [SerializeField]private Transform rowPrefab;
    [SerializeField]private Transform spawnPoint;
    private Transform currentRow;
    private TruthTable table;
    private void Awake() {
        ReadJson(File.ReadAllText(Application.streamingAssetsPath+"/TruthTable/truth01"+".json"));
        SpawnCell();
    }

    private void SpawnCell()
    {
        currentRow = Instantiate(rowPrefab,spawnPoint);
        int columnCount = table.input+table.output;
        int rowCount = table.rows.Length;
        Debug.Log(columnCount);
        Debug.Log(rowCount);
    }

    // public void SetTable(TruthTable table)
    // {
    //     this.table = table;
    // }

    private void ReadJson(string json)
    {
        // table = JsonUtility.FromJson<TruthTable>(json);
        table = JsonConvert.DeserializeObject<TruthTable>(json);
    }
}
