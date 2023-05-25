using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMap : MonoBehaviour
{
    [SerializeField]private Transform TextInput;
    private GameObject[] gates;
    private Button btn;
    private void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(saveGates);
    }
    private void saveGates()
    {
        MissionInfo allSave = new MissionInfo();
        gates = GameObject.FindGameObjectsWithTag("saveable");
        SaveGate[] saveGate = new SaveGate[gates.Length];
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
        allSave.missionName = TextInput.GetComponent<TMPro.TMP_InputField>().text;
        allSave.saveGates = saveGate;
        string json = JsonUtility.ToJson(allSave,true);

        MissionInfo test = JsonUtility.FromJson<MissionInfo>(json);
        foreach(SaveGate gate in test.saveGates)
        {
            Debug.Log(gate.posx);
        }
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/Custom/"+allSave.missionName+".json",json);
        transform.parent.gameObject.SetActive(false);
    }
}



