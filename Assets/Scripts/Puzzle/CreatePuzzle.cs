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
    [SerializeField]Transform spawnLine;
    private void readJson(string json)
    {
        MissionInfo loadPuzzle = JsonUtility.FromJson<MissionInfo>(json); // fix for puzzle leter
        
        CreateGate(loadPuzzle.saveGates);
        CreateLine(loadPuzzle.lines);
    }
    public void Start() {
        readJson(File.ReadAllText(Application.streamingAssetsPath+"/Custom/00.json"));
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
            else if(type.Equals("switch"))
            {
                gateObj = Instantiate(allGate.switchs,spawnPoint);
            }
            gateObj.name = gate.gateName;
            pos = gateObj.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(gate.posx,gate.posy);
            gateObj.Find("Image").GetComponent<DragDrop>().setDragable(false);
        }
    }

    private void CreateLine(Lines[] data)
    {
        foreach(Lines line in data)
        {
            RectTransform pos;
            Transform lineObj = Instantiate(allGate.line,spawnLine);
            Transform point1 = lineObj.Find("point1");
            Transform point2 = lineObj.Find("point2");
            pos = point1.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(line.pos1X,line.pos1Y);
            pos = point2.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(line.pos2X,line.pos2Y);

            Transform slot1 = spawnPoint.Find(line.c1Name).Find(line.c1Type.ToString());
            Transform slot2 = spawnPoint.Find(line.c2Name).Find(line.c2Type.ToString());

            point1.GetComponent<Drag>().setSlotPuzzle(slot1);
            slot1.GetComponent<Slot>().setLine(lineObj);
            point2.GetComponent<Drag>().setSlotPuzzle(slot2);
            slot2.GetComponent<Slot>().setLine(lineObj);

            point1.GetComponent<Drag>().setDragable(false);
            point2.GetComponent<Drag>().setDragable(false);
        }
    }
}
