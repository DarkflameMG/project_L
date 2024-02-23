using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonSelectBtn : MonoBehaviour
{
    [SerializeField]private string monName;
    [SerializeField]private Button btn;
    private MonsterDetailSys monsterDetailSys;

    private void Awake() {
        monsterDetailSys = GameObject.Find("MonsterDetailSys").GetComponent<MonsterDetailSys>();
        btn.onClick.AddListener(SendMonData);
    }

    private void SendMonData()
    {
        monsterDetailSys.SetMonName(monName);
    }
}
