using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMissionBtn : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    // [SerializeField]private GameObject missionSelectSystem;
    private void Start() 
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(onclick);
    }

    private void onclick()
    {
        lobbyinfo.isMissionSelect = false;
        lobbyinfo.isTypeSelect = true;
    }
}
