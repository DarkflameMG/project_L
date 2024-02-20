using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissionSelect : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private GameObject UI;
    [SerializeField]private GameObject mainMenuUI;
    [SerializeField]private GameObject questListUI;
    private void Update() {
        if(lobbyinfo.currentPage == Page.main)
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.currentPage = Page.none;
                UI.SetActive(false);
            }
        }
        else if(lobbyinfo.currentPage == Page.mainQuest)
        {
            mainMenuUI.SetActive(false);
            questListUI.SetActive(true);
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.currentPage = Page.none;
                ResetUI();
                UI.SetActive(false);
            }
            else if(Keyboard.current.tabKey.wasPressedThisFrame)
            {
                lobbyinfo.currentPage = Page.main;
                mainMenuUI.SetActive(true);
                questListUI.SetActive(false);
            }
        }
        else if(lobbyinfo.currentPage == Page.custom)
        {
            mainMenuUI.SetActive(false);
            UI.transform.GetChild(4).gameObject.SetActive(true);
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.currentPage = Page.none;
                ResetUI();
                UI.SetActive(false);
            }
            else if(Keyboard.current.tabKey.wasPressedThisFrame)
            {
                lobbyinfo.currentPage = Page.main;
                ResetUI();
            }
        }
    }

    public void Run()
    {
        lobbyinfo.currentPage = Page.main;
        UI.SetActive(true);
        ResetUI();
        mainMenuUI.SetActive(true);
    }

    private void ResetUI()
    {
        UI.transform.GetChild(4).gameObject.SetActive(false);
        questListUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
