using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetQuest : MonoBehaviour
{
    [SerializeField]private MissionSO missionSO;
    [SerializeField]private KeySO keySO;
    private Transform child;
    private MissionInfo data;
    private Button btn;
    private GameObject levelLoader;
    private GameObject ui;
    private void Awake() {
        levelLoader = GameObject.Find("LevelLoader");
        ui = GameObject.Find("UI");
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }
    public void SetQuestName_Data(string name,MissionInfo data)
    {
        child = transform.GetChild(1);
        child.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        this.data = data;
    }

    private void Click()
    {
        missionSO.missionInfo = data;
        // SceneManager.LoadScene("TestMap");
        ui.SetActive(false);
        keySO.keys = new();
        keySO.color = new();
        keySO.currentIndex = 0;
        levelLoader.GetComponent<LevelLoader>().LoadMission();
    }
}
