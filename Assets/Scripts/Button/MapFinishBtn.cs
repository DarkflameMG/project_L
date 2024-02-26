using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapFinishBtn : MonoBehaviour
{
    [SerializeField]private PlayerData playerData;
    [SerializeField]private MissionSO missionSO;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Completed);
    }

    private void Completed()
    {
        string missionName = missionSO.missionInfo.MissionName;
        if(!playerData.puzzleCompleted.Contains(missionName))
        {
            playerData.puzzleCompleted.Add(missionName);
        }
        SaveData saveData = GetComponent<SaveData>();
        saveData.SaveToJsonV2(playerData);
        SceneManager.LoadScene("lobby");
    }
}
