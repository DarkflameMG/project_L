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

    public void SpawnWrongRow(TruthTable table,int[] row)
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
        cell.Find("text").GetComponent<TMP_Text>().text = "Output";

        //column name
        foreach(string name in table.columnName)
        {
            cell = Instantiate(cellPrefab,columnName);
            cell.Find("text").GetComponent<TMP_Text>().text = name;
        }

        try
        {
            //wrong row
            foreach(int data in row)
            {
                cell = Instantiate(cellPrefab,truthRow);
                cell.Find("text").GetComponent<TMP_Text>().text = data.ToString();
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
}
