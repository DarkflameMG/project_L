using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestJSON : MonoBehaviour
{
    private void Start() {
        MissionData t1 = new MissionData();
        t1.position = new Vector3 (0,0,0);
        t1.health = 200;

        string json = JsonUtility.ToJson(t1);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath+"/Resources/Data/saveFile.json",json);
    }

    private class MissionData{
        public Vector3 position;
        public int health;
    }
}
