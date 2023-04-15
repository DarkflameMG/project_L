using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntingBtn : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private GameObject missionSystem;
    private void Start() {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(taskOnclick);
    }

    private void taskOnclick()
    {
        lobbyinfo.questType = QuestType.hunt;
        lobbyinfo.currentPage = Page.questList;
    }
}
