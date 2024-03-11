using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class SavePuzzleLog : MonoBehaviour
{
    [SerializeField]private Transform spawnGate;
    [SerializeField]private Transform spawnLine;
    [SerializeField]private MissionSO missionSO;
    private List<Transform> gates;
    private List<Transform> lines;

    public void StartSaveLog()
    {
        gates = new();
        lines = new();
        for(int i=0;i<spawnGate.childCount;i++)
        {
            gates.Add(spawnGate.GetChild(i));
        }

        for(int j=0;j<spawnLine.childCount;j++)
        {
            lines.Add(spawnLine.GetChild(j));
        }

        PuzzleLog puzzleLog = new();
        SaveGateLog[] saveGate = new SaveGateLog[gates.Count];
        Lines[] saveLines = new Lines[lines.Count];


        int k = 0;
        foreach(Transform gate in gates)
        {
            SaveGateLog newSave = new();
            RectTransform pos = gate.GetComponent<RectTransform>();
            newSave.gateName = gate.name;
            newSave.posx = pos.localPosition.x;
            newSave.posy = pos.localPosition.y;
            newSave.posz = pos.localPosition.z;

            if(gate.GetComponent<GateObject>().GetGateName().Equals("input") || gate.GetComponent<GateObject>().GetGateName().Equals("output"))
            {
                string ioName = gate.GetComponent<AddNameIO>().GetName();
                newSave.IOName = ioName;
            }
            saveGate[k] = newSave;
            k++;
        }
        
        int kk = 0;
        foreach(Transform line in lines)
        {
            Lines newLine = new();
            Transform child1 = line.transform.GetChild(1);
            Transform child2 = line.transform.GetChild(2);
            newLine.pos1X = child1.GetComponent<RectTransform>().localPosition.x;
            newLine.pos2X = child2.GetComponent<RectTransform>().localPosition.x;
            newLine.pos1Y = child1.GetComponent<RectTransform>().localPosition.y;
            newLine.pos2Y = child2.GetComponent<RectTransform>().localPosition.y;

            newLine.c1Name = child1.GetComponent<Drag>().GetGate().parent.name;
            newLine.c2Name = child2.GetComponent<Drag>().GetGate().parent.name;

            newLine.c1Type = child1.GetComponent<Drag>().GetGate().GetComponent<Slot>().GetSlotType();
            newLine.c2Type = child2.GetComponent<Drag>().GetGate().GetComponent<Slot>().GetSlotType();

            // newLine.expectBool = line.GetComponent<PowerLine>().GetCurrentState();

            saveLines[kk] = newLine;
            kk++;
        }


        puzzleLog.LogName = missionSO.missionInfo.MissionName;
        puzzleLog.saveGates = saveGate;
        puzzleLog.saveLines = saveLines;
        string json = JsonUtility.ToJson(puzzleLog,true);
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/Log/"+puzzleLog.LogName+"_Log"+".json",json);
    }
}
