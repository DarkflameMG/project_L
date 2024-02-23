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
    [SerializeField]WinSystem winSystem;
    [SerializeField]MapSystem mapSystem;
    private List<GameObject> bulbs;
    private void ReadJson(string json)
    {
        PuzzleInfo loadPuzzle = JsonUtility.FromJson<PuzzleInfo>(json); // fix for puzzle leter
        
        CreateGate(loadPuzzle.saveGates);
        CreateLine(loadPuzzle.lines);
        winSystem.SetBulbs(bulbs);
        winSystem.ReState();
    }
    public void StartGame()
    {
        bulbs = new List<GameObject>();
        RoomDetail room = mapSystem.GetCurrentRoomDetail();
        ReadJson(File.ReadAllText(Application.streamingAssetsPath+"/Puzzle/"+room.puzzleName+".json"));
        // Debug.Log(room.puzzleName);
    }

    private void CreateGate(SaveGate[] data)
    {
        foreach(SaveGate gate in data)
        {
            string type = gate.gateName.Split (delimiterChars)[0];
            RectTransform pos ;
            Transform gateObj = spawnPoint;
            if(type.Equals("high volt"))
            {
                gateObj = Instantiate(allGate.highVolt,spawnPoint);
            }
            else if(type.Equals("not"))
            {
                gateObj = Instantiate(allGate.not,spawnPoint);
            }
            else if(type.Equals("bulb"))
            {
                gateObj = Instantiate(allGate.bulb,spawnPoint);
                gateObj.gameObject.tag = "bulb";
                bulbs.Add(gateObj.gameObject);
            }
            else if(type.Equals("and"))
            {
                gateObj = Instantiate(allGate.and,spawnPoint);
            }
            else if(type.Equals("switch"))
            {
                gateObj = Instantiate(allGate.switchs,spawnPoint);
            }
            else if(type.Equals("placeholder1"))
            {
                gateObj = Instantiate(allGate.holder1,spawnPoint);
            }
            else if(type.Equals("placeholder2"))
            {
                gateObj = Instantiate(allGate.holder2,spawnPoint);
            }
            gateObj.name = gate.gateName;
            pos = gateObj.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(gate.posx,gate.posy);
            gateObj.Find("Image").GetComponent<DragDrop>().SetDragable(false);
            gateObj.GetComponent<GateObject>().SetIsPuzzle(true);
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

            point1.GetComponent<Drag>().SetSlotPuzzle(slot1);
            slot1.GetComponent<Slot>().SetLine(lineObj);
            point2.GetComponent<Drag>().SetSlotPuzzle(slot2);
            slot2.GetComponent<Slot>().SetLine(lineObj);

            point1.GetComponent<Drag>().SetDragable(false);
            point2.GetComponent<Drag>().SetDragable(false);

            lineObj.GetComponent<PowerLine2>().CreateLine();
            // lineObj.GetComponent<PowerLine2>().SetExpectBool(line.expectBool);
        }
    }
}
