using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMap : MonoBehaviour
{
    [SerializeField]private Transform TextInput;
    [SerializeField]private Transform saveProgress;
    private GameObject[] gates;
    private GameObject[] lines;
    private Button btn;
    private void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SaveGates);
    }
    private void SaveGates()
    {
        PuzzleInfo allSave = new PuzzleInfo();
        gates = GameObject.FindGameObjectsWithTag("saveable");
        lines = GameObject.FindGameObjectsWithTag("line");
        SaveGate[] saveGate = new SaveGate[gates.Length];
        Lines[] saveLine = new Lines[lines.Length];
        int i = 0;

        foreach(GameObject gate in gates)
        {
            SaveGate newSave = new SaveGate();
            RectTransform pos = gate.GetComponent<RectTransform>();
            newSave.gateName = gate.name;
            newSave.posx = pos.localPosition.x;
            newSave.posy = pos.localPosition.y;
            newSave.posz = pos.localPosition.z;


            saveGate[i] = newSave;
            i++;
        }

        int j = 0;
        foreach(GameObject line in lines)
        {
            Lines newLine = new Lines();
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

            newLine.expectBool = line.GetComponent<PowerLine>().GetCurrentState();

            saveLine[j] = newLine;
            j++;
        }



        allSave.PuzzleName = TextInput.GetComponent<TMPro.TMP_InputField>().text;
        allSave.saveGates = saveGate;
        allSave.lines = saveLine;
        string json = JsonUtility.ToJson(allSave,true);

        PuzzleInfo test = JsonUtility.FromJson<PuzzleInfo>(json);
        foreach(SaveGate gate in test.saveGates)
        {
            Debug.Log(gate.posx);
        }
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/Puzzle/"+allSave.PuzzleName+".json",json);
        transform.parent.gameObject.SetActive(false);

        saveProgress.GetComponent<SaveProgress>().SaveProgression();
    }
}



