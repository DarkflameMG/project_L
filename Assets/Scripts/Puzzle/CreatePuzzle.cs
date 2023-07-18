using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CreatePuzzle : MonoBehaviour
{
    char [] delimiterChars = { '_','(' };
    [SerializeField]GatesPrefabSO allGate;
    [SerializeField]Transform spawnPoint;
    private void readJson(string json)
    {
        MissionInfo loadPuzzle = JsonUtility.FromJson<MissionInfo>(json); // fix for puzzle leter
        
        CreateGate(loadPuzzle.saveGates);
    }
    public void Start() {
        readJson(File.ReadAllText(Application.streamingAssetsPath+"/Custom/And.json"));
    }

    private void CreateGate(SaveGate[] data)
    {
        foreach(SaveGate gate in data)
        {
            string type = gate.gateName.Split (delimiterChars)[0];
            RectTransform pos ;
            Transform gateObj = spawnPoint;
            Debug.Log(type);
            if(type.Equals("battery"))
            {
                gateObj = Instantiate(allGate.batterry,spawnPoint);
            }
            else if(type.Equals("not"))
            {
                gateObj = Instantiate(allGate.not,spawnPoint);
            }
            else if(type.Equals("bulb"))
            {
                gateObj = Instantiate(allGate.bulb,spawnPoint);
            }
            else if(type.Equals("and"))
            {
                gateObj = Instantiate(allGate.and,spawnPoint);
            }
            gateObj.name = gate.gateName;
            pos = gateObj.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(gate.posx,gate.posy);
        }
    }
}
