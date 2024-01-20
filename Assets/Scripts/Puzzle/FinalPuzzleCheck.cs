using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class FinalPuzzleCheck : MonoBehaviour
{
    [SerializeField]private GameObject checkBtn;
    [SerializeField]private GameObject exitBtn;
    [SerializeField]private GameObject StatusUI;
    [SerializeField]private TMP_Text statusText;
    [SerializeField]private CuurentTruthTableSO truthTableSO;
    [SerializeField]private Transform lines;
    private TruthTable table;
    private GameObject[] inputs;
    private GameObject[] outputs;
    private int[] wrongRow;
    private bool isPass;
    // private Transform
    private Button btn;

    private void Awake() {
        // table = truthTableSO.table;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Check);
    }

    public void Check()
    {
        isPass = false;
        StatusUI.SetActive(true);

        inputs = GameObject.FindGameObjectsWithTag("TableInput");
        outputs = GameObject.FindGameObjectsWithTag("TableOutput");

       StartCoroutine(CheckLoop());

    }
    public void SetTable()
    {
        // RoomDetail room = mapSystem.GetCurrentRoomDetail();
        Debug.Log(truthTableSO.tableName);
        ReadJson(File.ReadAllText(Application.streamingAssetsPath+"/TruthTable/"+truthTableSO.tableName+".json"));
    }

    private void ReadJson(string json)
    {
        table = JsonConvert.DeserializeObject<TruthTable>(json);
        // // Debug.Log(tableSO.table);
        // tableSO.table = table;
    }

    private IEnumerator CheckLoop()
    {
        StatusUI.GetComponent<StatusUI>().Delete();
        statusText.text = "Checking...";
        if(inputs.Length != 0)
        {
            isPass = true;

            int count = lines.childCount;
            for(int i=0;i<count;i++)
            {
                LineV2 line = lines.GetChild(i).Find("Line").GetComponent<LineV2>();
                line.Run();
            }

            for(int i=0;i<table.rows.Length;i++)
            {
                int[] row = table.rows[i];
                foreach(GameObject input in inputs)
                {
                    AddNameIO name = input.GetComponent<AddNameIO>();
                    int index = Array.IndexOf(table.columnName,name.GetName());
                    if(row[index] == 0)
                    {
                        input.GetComponent<GateObject>().SetState(false);
                    }
                    else
                    {
                        input.GetComponent<GateObject>().SetState(true);
                    }
                }

                yield return new WaitForSeconds(0.25f);

                foreach(GameObject output in outputs)
                {
                    AddNameIO name = output.GetComponent<AddNameIO>();
                    int index = Array.IndexOf(table.columnName,name.GetName());
                    bool truth = false;
                    if(row[index] == 1)
                    {
                        truth = true;
                    }

                    if(truth != output.GetComponent<GateObject>().GetCurrentState())
                    {
                        isPass = false;
                        wrongRow = row;
                        break;
                    }
                }
            }
        }

        if(isPass)
        {
            statusText.text = "Pass";
        }
        else
        {
            statusText.text = "Fail";
            StatusUI.GetComponent<StatusUI>().SpawnWrongRow(table,wrongRow);
        }
    }
}
