using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using Newtonsoft.Json;

public class PuzzleListSys : MonoBehaviour
{
    [SerializeField]private Transform puzzleListPrefab;
    [SerializeField]private Transform puzzleKeyListPrefab;
    [SerializeField]private Transform listSpawnPoint;
    [SerializeField]private Transform truthTablePoint;
    [SerializeField]private Transform keySpawnPoint;

    private void Start() {
        ReadFileName();
    }
    private void SpawnList(PuzzleInfo puzzleInfo, Transform spawnPoint)
    {
        if(puzzleInfo.PuzzleName != null)
        {
            Transform PList = Instantiate(puzzleListPrefab,spawnPoint);
            PList.name = puzzleInfo.PuzzleName;
            PList.GetChild(0).GetComponent<TMP_Text>().text = puzzleInfo.PuzzleName;
        }
    }
    private void SpawnListTruthTable(TruthTable table, Transform spawnPoint)
    {
        if(table.tableName != null)
        {
            Transform PList = Instantiate(puzzleListPrefab,spawnPoint);
            PList.name = table.tableName;
            PList.GetChild(0).GetComponent<TMP_Text>().text = table.tableName;
        }
    }

    private void ReadFileName()
    {
        var jsonFile = Directory.EnumerateFiles(Application.streamingAssetsPath+"/Puzzle","*.json");
        foreach (string fileName in jsonFile)
        {
            ReadJson(File.ReadAllText(fileName),listSpawnPoint);
        }

        var jsonFile2 = Directory.EnumerateFiles(Application.streamingAssetsPath+"/TruthTable","*.json");
        foreach (string fileName in jsonFile2)
        {
            ReadJsonV2(File.ReadAllText(fileName),truthTablePoint);
        }
    }

    private void ReadJson(string json, Transform spawnPoint)
    {
        PuzzleInfo loadPuzzle = JsonUtility.FromJson<PuzzleInfo>(json);
        SpawnList(loadPuzzle,spawnPoint);
    }

    private void ReadJsonV2(string json, Transform spawnPoint)
    {
        TruthTable loadTable = JsonConvert.DeserializeObject<TruthTable>(json);
        SpawnListTruthTable(loadTable,spawnPoint);
    }
}
