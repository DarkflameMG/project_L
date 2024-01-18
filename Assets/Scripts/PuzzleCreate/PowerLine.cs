using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour,IPowerLine
{
    private bool currentState = false;
    public bool GetCurrentState()
    {
        return currentState;
    }
    public void SetState(bool state)
    {
        currentState = state;
    }
    public void RunLine()
    {
        //noting
    }

    public void StopLine()
    {
        //noting
    }

    private void Update() {
        // Debug.Log(currentState);
    }
}
