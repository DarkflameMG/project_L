using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNumberSystem : MonoBehaviour
{
    private int numberOfGate = 0;
    // private int numberOfLine = 0;

    public int getGateNum()
    {
        numberOfGate++;
        return numberOfGate;
    }
}
