using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetQuest : MonoBehaviour
{
    [SerializeField]private MissionSO missionSO;
    private Transform child;
    private MissionInfo data;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(click);
    }
    public void setQuestName_Data(string name,MissionInfo data)
    {
        child = transform.GetChild(1);
        child.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        this.data = data;
    }

    private void click()
    {
        missionSO.missionInfo = data;
        SceneManager.LoadScene("TestMap");
    }
}
