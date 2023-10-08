using System.Collections;
using System.Collections.Generic;
// using System.Text.Json;
using System.IO;
using UnityEngine;

public class SpawnQuestSys : MonoBehaviour
{
    [SerializeField]private Transform SpawnLocation;
    [SerializeField]private Transform QuestPrefab;
    private float i =0;

    private void readJson(string json)
    {
        MissionInfo loadMission = JsonUtility.FromJson<MissionInfo>(json);
        Debug.Log(loadMission.missionName);
        Transform thisQuest = spawnQuest();
        thisQuest.GetComponent<SetQuest>().SetQuestName_Data(loadMission.missionName,loadMission);
    }

    private void Start() {
        var jsonFile = Directory.EnumerateFiles(Application.streamingAssetsPath+"/Map","*.json");
        foreach (string fileName in jsonFile)
        {
            readJson(File.ReadAllText(fileName));

            // Debug.Log(File.ReadAllText(fileName));
        }
    }


    private Transform spawnQuest()
    {
        Transform thisQuest = Instantiate(QuestPrefab,SpawnLocation);
        thisQuest.SetLocalPositionAndRotation(new Vector3(0,i,0),Quaternion.identity);
        i-=150;
        return thisQuest;
    }
}
