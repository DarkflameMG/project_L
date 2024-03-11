using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUI : MonoBehaviour
{
    [SerializeField]private Transform ioHeader;
    [SerializeField]private Transform columnName;
    [SerializeField]private Transform truthRow;
    [SerializeField]private Transform cellPrefab;
    [SerializeField]private GameObject wrongTable;

    public void SpawnWrongRow(TruthTable table,int[] row,List<bool> actualOutput,List<string> outputHeader)
    {
        Transform cell;

        //io header
        cell = Instantiate(cellPrefab,ioHeader);
        cell.GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.input,100f);
        cell.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.input-5,100f);
        cell.Find("text").GetComponent<TMP_Text>().text = "Input";

        cell = Instantiate(cellPrefab,ioHeader);
        cell.GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.output,100f);
        cell.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.output-5,100f);
        cell.Find("text").GetComponent<TMP_Text>().text = "Expect Output";

        cell = Instantiate(cellPrefab,ioHeader);
        cell.GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.output,100f);
        cell.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(150f*table.output-5,100f);
        cell.Find("text").GetComponent<TMP_Text>().text = "Actual Output";

        //column name
        foreach(string name in table.columnName)
        {
            cell = Instantiate(cellPrefab,columnName);
            cell.Find("text").GetComponent<TMP_Text>().text = name;
        }

        int startOutput = table.input;
        int endOutput = table.input+table.output;
        for(int k=startOutput;k<endOutput;k++)
        {
            cell = Instantiate(cellPrefab,columnName);
            cell.Find("text").GetComponent<TMP_Text>().text = table.columnName[k];
        }

        try
        {
            //wrong row
            foreach(int data in row)
            {
                cell = Instantiate(cellPrefab,truthRow);
                cell.Find("text").GetComponent<TMP_Text>().text = data.ToString();
            }

            for(int k=startOutput;k<endOutput;k++)
            {
                int num = 0;
                bool truthData = actualOutput[outputHeader.IndexOf(table.columnName[k])];
                if(truthData == true)
                {
                    num = 1;
                }
                cell = Instantiate(cellPrefab,truthRow);
                cell.Find("text").GetComponent<TMP_Text>().text = num.ToString();
            }
        }
        catch
        {

        }
    }

    public void Delete()
    {
        int ioC = ioHeader.childCount;
        int columnC = columnName.childCount;
        int truthC = truthRow.childCount;

        for(int i=0;i<ioC;i++)
        {
            Destroy(ioHeader.GetChild(i).gameObject);
        }
        for(int i=0;i<columnC;i++)
        {
            Destroy(columnName.GetChild(i).gameObject);
        }
        for(int i=0;i<truthC;i++)
        {
            Destroy(truthRow.GetChild(i).gameObject);
        }
    }

    public void Hide()
    {
        wrongTable.SetActive(false);
    }

    public void Show()
    {
        wrongTable.SetActive(true);
    }
}
