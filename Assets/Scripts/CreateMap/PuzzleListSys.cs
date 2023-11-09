using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PuzzleListSys : MonoBehaviour
{
    [SerializeField]private Transform puzzleListPrefab;
    [SerializeField]private Transform listSpawnPoint;

    private void Start() {
        ReadFileName();
    }
    private void SpawnList(PuzzleInfo puzzleInfo)
    {
        if(puzzleInfo.PuzzleName != null)
        {
            Transform PList = Instantiate(puzzleListPrefab,listSpawnPoint);
            PList.name = puzzleInfo.PuzzleName;
            PList.GetChild(0).GetComponent<TMP_Text>().text = puzzleInfo.PuzzleName;
        }
    }

    private void ReadFileName()
    {
        var jsonFile = Directory.EnumerateFiles(Application.streamingAssetsPath+"/Puzzle","*.json");
        foreach (string fileName in jsonFile)
        {
            ReadJson(File.ReadAllText(fileName));
        }
    }

    private void ReadJson(string json)
    {
        PuzzleInfo loadPuzzle = JsonUtility.FromJson<PuzzleInfo>(json);
        SpawnList(loadPuzzle);
    }
}
