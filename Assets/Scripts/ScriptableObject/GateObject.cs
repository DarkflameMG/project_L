using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObject : MonoBehaviour
{
    [SerializeField]private GateSO gateSO;

    public GateSO GetGateSO()
    {
        return gateSO;
    }
}
