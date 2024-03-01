using System.Collections;
using System.Collections.Generic;
// using System.Text.Json;
using System.IO;
using UnityEngine;

public class SpawnQuestSys : MonoBehaviour
{
    [SerializeField]private Transform SpawnLocation;
    [SerializeField]private Transform mainQuestLocation;
    [SerializeField]private Transform QuestPrefab;
    private float i =0;

    private void ReadJson(string json,Transform location,bool isMain)
    {
        MissionInfo loadMission = JsonUtility.FromJson<MissionInfo>(json);
        // Debug.Log(loadMission.MissionName);
        Transform thisQuest = SpawnQuest(location);
        thisQuest.GetComponent<SetQuest>().SetQuestName_Data(loadMission.MissionName,loadMission);
        thisQuest.GetComponent<SetQuest>().SetRequire("");
        if(isMain)
        {
            if(loadMission.MissionName.Equals("Map2"))
            {
                Debug.Log(thisQuest);
                thisQuest.GetComponent<SetQuest>().SetRequire("Map1");
            }
            else if(loadMission.MissionName.Equals("Map3"))
            {
                thisQuest.GetComponent<SetQuest>().SetRequire("Map2");
            }
            else if(loadMission.MissionName.Equals("Map4"))
            {
                thisQuest.GetComponent<SetQuest>().SetRequire("Map3");
            }
            else if(loadMission.MissionName.Equals("Map5"))
            {
                thisQuest.GetComponent<SetQuest>().SetRequire("Map4");
            }
            else if(loadMission.MissionName.Equals("Map6"))
            {
                thisQuest.GetComponent<SetQuest>().SetRequire("Map5");
            }
            else if(loadMission.MissionName.Equals("Next Step"))
            {
                thisQuest.GetComponent<SetQuest>().SetRequire("Map6");
            }
        }
    }

    private void Start() {
        // Debug.Log(Application.dataPath);
        var jsonFile = Directory.EnumerateFiles(Application.streamingAssetsPath+"/CustomMap","*.json");
        foreach (string fileName in jsonFile)
        {
            ReadJson(File.ReadAllText(fileName),SpawnLocation,false);
        }
        // var mainQuest = Directory.EnumerateFiles(Application.dataPath+"/Resources/MissionJson","*.json");
        var mainQuest = Resources.LoadAll("MissionJson",typeof(TextAsset));
        // foreach (string fileName in mainQuest)
        // {
        //     ReadJson(File.ReadAllText(fileName),mainQuestLocation);
        // }
        foreach(Object quest in mainQuest)
        {
            ReadJson(quest.ToString(),mainQuestLocation,true);
        }
    }


    private Transform SpawnQuest(Transform location)
    {
        Transform thisQuest = Instantiate(QuestPrefab,location);
        thisQuest.SetLocalPositionAndRotation(new Vector3(0,i,0),Quaternion.identity);
        i-=150;
        return thisQuest;
    }
}
