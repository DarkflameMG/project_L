using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;

public class FinalPuzzleCheck : MonoBehaviour
{
    [SerializeField]private GameObject checkBtn;
    [SerializeField]private GameObject exitBtn;
    [SerializeField]private GameObject StatusUI;
    [SerializeField]private TMP_Text statusText;
    [SerializeField]private CuurentTruthTableSO truthTableSO;
    [SerializeField]private Transform lines;
    [SerializeField]private GameObject puzzleComplete;
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
        StatusUI.GetComponent<StatusUI>().Hide();
        inputs = GameObject.FindGameObjectsWithTag("TableInput");
        outputs = GameObject.FindGameObjectsWithTag("TableOutput");

        if(CheckInput())
        {
            if(CheckOutput())
            {
                StartCoroutine(CheckLoop());
            }
            else
            {
                statusText.text = "Output Not Match with truth table";
                Debug.Log("Output Not Completed");
            }
        }
        else
        {
            statusText.text = "Input Not Match with truth table";
            Debug.Log("Input Not Completed");
        }

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

    private bool CheckInput()
    {
        int intputCount = table.input;
        //Input Check
        List<String> inputNames = table.columnName.Take(intputCount).ToList();
        for(int i=0;i<intputCount;i++)
        {
            bool haveAllName = false;
            string tableIntputName = table.columnName[i];
            foreach(GameObject input in inputs)
            {
                string inputName = input.GetComponent<AddNameIO>().GetName();
                if(inputName.Equals(tableIntputName))
                {
                    haveAllName = true;
                }
                if(!inputNames.Contains(inputName))
                {
                    return false;
                }
            }
            if(!haveAllName)
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckOutput()
    {
        int intputCount = table.input;
        int allCount = table.input+table.output;
        List<String> outputNames = table.columnName.Skip(intputCount).Take(table.output).ToList();
        // Debug.Log(outputNames.Count);
        //Output Check
        for(int i=intputCount;i<allCount;i++)
        {
            bool haveAllName = false;
            string tableOutputName = table.columnName[i];
            // Debug.Log(tableOutputName);
            foreach(GameObject output in outputs)
            {
                string outputName = output.GetComponent<AddNameIO>().GetName();
                // Debug.Log(outputName);
                if(outputName.Equals(tableOutputName))
                {
                    haveAllName = true;
                }
                if(!outputNames.Contains(outputName))
                {
                    return false;
                }
            }
            if(!haveAllName)
            {
                return false;
            }
        }
        return true;
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

                yield return new WaitForSeconds(0.5f);

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
            statusText.text = "You Pass";
            puzzleComplete.SetActive(true);
        }
        else
        {
            statusText.text = "You Fail this case";
            StatusUI.GetComponent<StatusUI>().Show();
            StatusUI.GetComponent<StatusUI>().SpawnWrongRow(table,wrongRow);
        }
    }
}
