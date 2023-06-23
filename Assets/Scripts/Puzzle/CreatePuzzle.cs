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
        
        Create(loadPuzzle.saveGates);
    }
    public void Start() {
        readJson(File.ReadAllText(Application.streamingAssetsPath+"/Custom/test2.json"));
    }
    private void Create(SaveGate[] data)
    {
        foreach(SaveGate gate in data)
        {
            string type = gate.gateName.Split (delimiterChars)[0];
            RectTransform pos = spawnPoint.GetComponent<RectTransform>();//dummy
            Debug.Log(type);
            if(type.Equals("battery"))
            {
                pos = Instantiate(allGate.batterry,spawnPoint).GetComponent<RectTransform>();
            }
            else if(type.Equals("not"))
            {
                pos = Instantiate(allGate.not,spawnPoint).GetComponent<RectTransform>();
            }
            else if(type.Equals("bulb"))
            {
                pos = Instantiate(allGate.bulb,spawnPoint).GetComponent<RectTransform>();
            }
            else if(type.Equals("and"))
            {
                pos = Instantiate(allGate.and,spawnPoint).GetComponent<RectTransform>();
            }
            pos.anchoredPosition = new Vector2(gate.posx,gate.posy);
        }
    }
}
