using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetQuest : MonoBehaviour
{
    private Transform child;
    private SaveGates data;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(click);
    }
    public void setQuestName_Data(string name,SaveGates data)
    {
        child = transform.GetChild(1);
        child.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        this.data = data;
    }

    private void click()
    {
        Debug.Log(data.missionName);
    }
}
