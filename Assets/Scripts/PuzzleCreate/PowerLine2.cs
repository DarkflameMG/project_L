using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine2 : MonoBehaviour,IPowerLine
{
    [SerializeField]private Line2Tone line1;
    private bool currentState = false;
    private bool expectBool = false;
    public bool GetCurrentState()
    {
        return currentState;
    }
    public void SetState(bool state)
    {
        currentState = state;
    }

    public void CreateLine()
    {
        line1.LineCreate();
    }
    public void RunLine()
    {
        line1.RunLine();
    }

    public void StopLine()
    {
        currentState = false;
        line1.StopLine();
    }

    public void SetExpectBool(bool expect)
    {
        expectBool = expect;
    }
    public bool GetExpectBool()
    {
        return expectBool;
    }
}
