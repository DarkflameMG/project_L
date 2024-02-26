using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMapBtn : MonoBehaviour
{
    [SerializeField]private GameObject turnbase;
    private Button btn;
    private DontDestroyMap dontDestroyMap;

    private void Awake() {
        btn = GetComponent<Button>();
        if(GameObject.Find("mapControlScript") != null)
        {
            dontDestroyMap = GameObject.Find("mapControlScript").GetComponent<DontDestroyMap>();
        }
        btn.onClick.AddListener(Return);
    }

    private void Return()
    {
        dontDestroyMap.FightToMap();
        Destroy(turnbase);
    }
}
