using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearAll : MonoBehaviour
{
    [SerializeField]Transform gates;
    [SerializeField]Transform lines;
    private Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetCircuit);
    }

    
    private void ResetCircuit()
    {
        DeletedLoop(gates,gates.childCount);
        DeletedLoop(lines,lines.childCount);
    }

    private void DeletedLoop(Transform obj,int counter)
    {
        for(int i = 0;i < counter;i++)
        {
            Destroy(obj.GetChild(i).gameObject);
        }
    }
}
