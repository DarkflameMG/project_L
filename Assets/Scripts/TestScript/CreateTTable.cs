using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class CreateTTable : MonoBehaviour
{
    [SerializeField]private Transform ttablePre;
    [SerializeField]private GameObject X1;
    [SerializeField]private GameObject X2;
    [SerializeField]private GameObject X3;
    [SerializeField]private GameObject X4;
    [SerializeField]private GameObject Y1;
    [SerializeField]private GameObject Y2;
    [SerializeField]private GameObject Y3;
    [SerializeField]private GameObject Y4;

    private void ReadJson(string json)
    {
        TruthTable table = JsonUtility.FromJson<TruthTable>(json);
        if(table.X1 != null )
        {
            X1.SetActive(true);
            SpawnCell(table.X1,X1.transform);
        }
        if(table.X2 != null  )
        {
            X2.SetActive(true);
            SpawnCell(table.X2,X2.transform);
        }
        if(table.X3 != null )
        {
            X3.SetActive(true);
            SpawnCell(table.X3,X3.transform);
        }
        if(table.X4 != null  )
        {
            X4.SetActive(true);
            SpawnCell(table.X4,X4.transform);
        }
        if(table.Y1 != null  )
        {
            Y1.SetActive(true);
            SpawnCell(table.Y1,Y1.transform);
        }
        if(table.Y2 != null  )
        {
            Y2.SetActive(true);
            SpawnCell(table.Y2,Y2.transform);
        }
        if(table.Y3 != null  )
        {
            Y3.SetActive(true);
            SpawnCell(table.Y3,Y3.transform);
        }
        if(table.Y4 != null  )
        {
            Y4.SetActive(true);
            SpawnCell(table.Y4,Y4.transform);
        }
    }

    private void Start() {
        ReadJson(File.ReadAllText(Application.streamingAssetsPath+"/TruthTable/"+"truth01"+".json"));
    }

    private void SpawnCell(int[] data,Transform spawnPoint)
    {
        for(int i = 0 ; i < data.Length; i++ )
        {
            Transform cell = Instantiate(ttablePre,spawnPoint);
            cell.Find("Text").GetComponent<TMP_Text>().text = data[i].ToString();
        }
    }
}
