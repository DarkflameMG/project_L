using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    private bool currentState = false;
    public bool getCurrentState()
    {
        return currentState;
    }
    public void setState(bool state)
    {
        currentState = state;
    }
}
