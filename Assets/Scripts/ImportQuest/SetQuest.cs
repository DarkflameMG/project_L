using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetQuest : MonoBehaviour
{
    [SerializeField]private MissionSO missionSO;
    private Transform child;
    private PuzzleInfo data;
    private Button btn;
    private GameObject levelLoader;
    private GameObject ui;
    private void Awake() {
        levelLoader = GameObject.Find("LevelLoader");
        ui = GameObject.Find("UI");
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }
    public void SetQuestName_Data(string name,PuzzleInfo data)
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
        levelLoader.GetComponent<LevelLoader>().LoadMission();
    }
}
