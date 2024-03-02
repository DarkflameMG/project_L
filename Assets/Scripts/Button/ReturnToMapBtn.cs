using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMapBtn : MonoBehaviour
{
    [SerializeField]private GameObject turnbase;
    [SerializeField]private TMP_Text statusFight;
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
        if(statusFight.text.Equals("Player Win..."))
        {
            dontDestroyMap.FightToMap(true);
        }
        else if(statusFight.text.Equals("Player Dead.."))
        {
            dontDestroyMap.FightToMap(false);
        }
        Destroy(turnbase);
    }
}
