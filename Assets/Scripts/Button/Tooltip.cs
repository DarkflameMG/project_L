using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private string gateName;
    private string desc;

    private void Start() {
        GateSO gateSO = GetComponent<SpawnGate>().GetGateSO();
        gateName = gateSO.name;
        desc = gateSO.description;
    }
    private void OnMouseEnter() {
        TooltipManager._instance.SetAndShow(gateName,desc);
        Debug.Log("show");
    }
    private void OnMouseExit() {
        TooltipManager._instance.Hide();
    }
}
