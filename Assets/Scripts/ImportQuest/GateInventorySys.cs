using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInventorySys : MonoBehaviour
{
    [SerializeField]private Transform gateItemSpawnPoint;

    public void ReCheck()
    {
        int count = gateItemSpawnPoint.childCount;
        for(int i=0;i<count;i++)
        {
            GateItem gateItem = gateItemSpawnPoint.GetChild(i).GetComponent<GateItem>();
            gateItem.Check();
        }
    }
}
