using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using UnityEngine;

public class SpawnQuestSys : MonoBehaviour
{
    private void readJson()
    {
        // var jsonFile = Directory.EnumerateFiles(Application.streamingAssetsPath+"/Custom/YourCreations","*.json");
        // foreach (string fileName in jsonFile)
        // {
        //     Debug.Log(fileName);
        // }
    }
    private void Start() {
        var jsonFile = Directory.EnumerateFiles(Application.streamingAssetsPath+"/Custom/YourCreations","*.json");
        foreach (string fileName in jsonFile)
        {
            Debug.Log(File.ReadAllText(fileName));
        }
    }
}
