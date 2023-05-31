using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInfo : MonoBehaviour
{
    void Awake()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Upgrade/upgradeSystem");
        Debug.Log(json);
    }
}
