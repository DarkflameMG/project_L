using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObject : MonoBehaviour
{
    [SerializeField]private GateSO gateSO;
    private int slot1 = 2;
    private int slot2 = 2;

    public GateSO GetGateSO()
    {
        return gateSO;
    }

    public int getCurrentState()
    {
        return 1;
    }
}
