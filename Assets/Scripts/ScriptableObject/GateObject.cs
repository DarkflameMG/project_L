using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObject : MonoBehaviour
{
    [SerializeField]private GateSO gateSO;
    private string gateName;
    private void Awake() {
        gateName = gateSO.gateName;
    }
    private bool currentState = false;
    private bool slot1 = false;
    // private int slot2 = 2;

    public GateSO GetGateSO()
    {
        return gateSO;
    }

    public bool getCurrentState()
    {
        return currentState;
    }
    private void Update() {
        if(gateName.Equals("battery"))
        {
            currentState = true;
        }
        else if(gateName.Equals("bub"))
        {
            currentState = slot1;
        }
        else if(gateName.Equals("not"))
        {
            currentState = !slot1;
        }
    }

    public void SetSlot1(bool value)
    {
        slot1 = value;
    }
    public void SetSlot2(bool value)
    {
        slot1 = value;
    }
}
