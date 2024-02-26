using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMapBtn : MonoBehaviour
{
    private Button btn;
    private DontDestroyMap dontDestroyMap;

    private void Awake() {
        btn = GetComponent<Button>();
        dontDestroyMap = GameObject.Find("mapControlScript").GetComponent<DontDestroyMap>();
        btn.onClick.AddListener(Return);
    }

    private void Return()
    {
        dontDestroyMap.FightToMap();
    }
}
