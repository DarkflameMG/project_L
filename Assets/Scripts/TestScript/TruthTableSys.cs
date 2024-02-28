using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class TruthTableSys : MonoBehaviour
{
    [SerializeField]private Transform cellPrefab;
    [SerializeField]private Transform rowPrefab;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private GameObject tableUI;
    [SerializeField]private MissionSO missionSO;
    [SerializeField]private PlayPuzzle playPuzzle;
    private Transform currentRow;
    private TruthTable table;
    private bool state = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        state = !state;
        tableUI.SetActive(state);
        playPuzzle.HideMap();
    }

    private void Awake() {
        string puzzleName = missionSO.missionInfo.truthTables[0];
        ReadJson(File.ReadAllText(Application.streamingAssetsPath+"/TruthTable/"+puzzleName+".json"));
        SpawnCell();
    }

    private void SpawnCell()
    {
        Transform cell;
        currentRow = Instantiate(rowPrefab,spawnPoint);
        int columnCount = table.input+table.output;
        int rowCount = table.rows.Length;

        //in out
        cell = Instantiate(cellPrefab,currentRow);
        cell.GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.input,100f);
        cell.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.input-5,100f);
        cell.Find("text").GetComponent<TMP_Text>().text = "Input";
        cell = Instantiate(cellPrefab,currentRow);
        cell.GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.output,100f);
        cell.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.output-5,100f);
        cell.Find("text").GetComponent<TMP_Text>().text = "Output";

        currentRow = Instantiate(rowPrefab,spawnPoint);
        //header
        for(int i=0;i<columnCount;i++)
        {
            cell = Instantiate(cellPrefab,currentRow);
            cell.Find("text").GetComponent<TMP_Text>().text = table.columnName[i];
        }

        for(int j = 0;j < rowCount; j++)
        {
            currentRow = Instantiate(rowPrefab,spawnPoint);
            int[] row = table.rows[j];
            for(int i=0;i<columnCount;i++)
            {
                cell = Instantiate(cellPrefab,currentRow);
                cell.Find("text").GetComponent<TMP_Text>().text = row[i].ToString();
            }
        }
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
