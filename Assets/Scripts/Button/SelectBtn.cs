using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBtn : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private Page page;
    [SerializeField]private QuestType questType;

    private void Start() {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnclick);
    }

    private void TaskOnclick()
    {
        lobbyinfo.questType = questType;
        lobbyinfo.currentPage = page;
    }
}
