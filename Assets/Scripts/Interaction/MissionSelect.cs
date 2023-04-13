using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissionSelect : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private GameObject UI;
    [SerializeField]private GameObject mainMenuUI;
    [SerializeField]private GameObject typeMenuUI;
    private void Update() {
        if(lobbyinfo.isMissionSelect)
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.isMissionSelect = false;
                UI.SetActive(false);
            }
        }
        else if(lobbyinfo.isTypeSelect)
        {
            mainMenuUI.SetActive(false);
            typeMenuUI.SetActive(true);
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.isMissionSelect = false;
                lobbyinfo.isTypeSelect = false;
                resetUI();
                UI.SetActive(false);
            }
            else if(Keyboard.current.tabKey.wasPressedThisFrame)
            {
                lobbyinfo.isTypeSelect = false;
                lobbyinfo.isMissionSelect = true;
                resetUI();
            }
        }
    }

    public void run()
    {
        lobbyinfo.isMissionSelect = true;
        UI.SetActive(true);
        mainMenuUI.SetActive(true);
    }

    private void resetUI()
    {
        typeMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
