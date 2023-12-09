using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine2 : MonoBehaviour,IPowerLine
{
    [SerializeField]private Line2Tone line1;
    [SerializeField]private Line2Tone line2;
    private bool currentState = false;
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
        line2.LineCreate();
    }
    public void RunLine()
    {
        line1.RunLine();
        line2.RunLine();
    }

    public void StopLine()
    {
        currentState = false;
        line1.StopLine();
        line2.StopLine();
    }
}
