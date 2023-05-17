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
        SaveGates allSave = new SaveGates();
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

        SaveGates test = JsonUtility.FromJson<SaveGates>(json);
        foreach(SaveGate gate in test.saveGates)
        {
            Debug.Log(gate.posx);
        }
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/Custom/YourCreations/"+allSave.missionName+".json",json);
        transform.parent.gameObject.SetActive(false);
    }
}

[System.Serializable]
public class SaveGate
{
    public string gateName;
    public float posx;
    public float posy;
    public float posz;
}

[System.Serializable]
public class SaveGates
{
    public string missionName;
    public SaveGate[] saveGates;
}

