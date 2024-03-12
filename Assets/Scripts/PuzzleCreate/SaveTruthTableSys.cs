using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class SaveTruthTableSys : MonoBehaviour
{
    [SerializeField]private TMP_InputField tableName;
    [SerializeField]private TMP_Dropdown noInput;
    [SerializeField]private TMP_Dropdown noOutput;
    [SerializeField]private TMP_InputField columnName;
    [SerializeField]private TMP_InputField tableRow;
    [SerializeField]private GameObject saveCompletedUI;
    [SerializeField]private GameObject saveFailUI;

    private readonly char[] chars = {','};
    private readonly char[] chars2 = {'['};
    public void StartSave()
    {
        if(tableName.text.Equals("") || columnName.text.Equals("") || tableRow.text.Equals(""))
        {
            throw new ArgumentException();
        }
        TruthTable newTruthTable = new();
        string table_name = tableName.text; 
        string[] column_names = columnName.text.Split(chars);
        string[] newColumnNames = new string[noOutput.value+noInput.value+2];
        string[] tableARow = tableRow.text.Split(chars2);

        int i=0;
        foreach(string s in column_names)
        {
            newColumnNames[i] = s.Replace(" ","");
            // Debug.Log(newColumnNames[i]);
            i++;
        }

        i=0;
        foreach(string s in tableARow)
        {
            tableARow[i] = s.Replace(" ","").Replace("]","");
            // Debug.Log(tableARow[i]);
            i++;
        }

        int[][] rows = new int[tableARow.Length-1][];
        for(int j=1;j<tableARow.Length;j++)
        {
            int[] columns = new int[noOutput.value+noInput.value+2];
            string[] test = tableARow[j].Split(chars);

            int k = 0;
            foreach(string s in test)
            {
                columns[k] = Int32.Parse(s);
                k++;
            }
            rows[j-1] = columns;
        }



        newTruthTable.tableName = table_name;
        newTruthTable.input = noInput.value+1;
        newTruthTable.output = noOutput.value+1;
        newTruthTable.columnName = newColumnNames;
        newTruthTable.rows =rows;
        
        JsonSerializerSettings jsonSetting = new()
        {
            DefaultValueHandling = DefaultValueHandling.Include, 
        };

        string json = JsonConvert.SerializeObject(newTruthTable,jsonSetting);
        System.IO.File.WriteAllText(Application.dataPath + "/StreamingAssets/TruthTable/"+table_name+".json",json);
    }

    public void PreStart()
    {
        try
        {
            StartSave();
            StartCoroutine(ShowUI(true));
        }
        catch
        {
            Debug.Log("Something error!");
            StartCoroutine(ShowUI(false));
        }
    }

    private IEnumerator ShowUI(bool isCompleted)
    {
        if(isCompleted)
        {
            saveCompletedUI.SetActive(true);
        }
        else
        {
            saveFailUI.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        saveCompletedUI.SetActive(false);
        saveFailUI.SetActive(false);
    }
}
