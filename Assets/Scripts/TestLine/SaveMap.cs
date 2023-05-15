using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMap : MonoBehaviour
{
    private GameObject[] gates;
    private Button btn;
    private void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(saveGates);
    }
    private void saveGates()
    {
        gates = GameObject.FindGameObjectsWithTag("saveable");
        // Debug.Log(p1.gates.Length);
    }
}
