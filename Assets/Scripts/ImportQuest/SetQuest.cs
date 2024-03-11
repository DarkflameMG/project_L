using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetQuest : MonoBehaviour
{
    [SerializeField]private MissionSO missionSO;
    [SerializeField]private KeySO keySO;
    [SerializeField]private Sprite inactive;
    [SerializeField]private PlayerData playerData;
    [SerializeField]private Image image;
    private string requireQuest;
    private Transform child;
    private MissionInfo data;
    private Button btn;
    private GameObject levelLoader;
    private GameObject ui;
    private List<string> completedMap;
    private bool isActive = true;
    private void Awake() {
        levelLoader = GameObject.Find("LevelLoader");
        ui = GameObject.Find("UI");
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
        completedMap = playerData.puzzleCompleted;
    }
    public void SetQuestName_Data(string name,MissionInfo data)
    {
        child = transform.GetChild(1);
        child.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        this.data = data;
    }

    private void Update() {
        
    }

    private void Click()
    {
        if(isActive  && !data.MissionName.Equals("Next Step"))
        {
            missionSO.missionInfo = data;
            // SceneManager.LoadScene("TestMap");
            ui.SetActive(false);
            keySO.currentKeys = new();
            keySO.color = new();
            keySO.currentIndex = 0;
            levelLoader.GetComponent<LevelLoader>().LoadMission();
        }
        else if(isActive  && data.MissionName.Equals("Next Step"))
        {
            Application.OpenURL("https://forms.office.com/r/Y8ETGBLHgQ"); // group1 Test
            // Application.OpenURL("https://forms.office.com/r/RUyezDbj8D"); // group2 Finish
        }
    }

    public void SetRequire(string name)
    {
        requireQuest = name;
        if(!name.Equals(""))
        {
            completedMap = playerData.puzzleCompleted;
            if(!completedMap.Contains(requireQuest))
            {
                isActive = false;
                image.sprite = inactive;
            }
            // else
            // {
                
            // }
        }
    }
}
