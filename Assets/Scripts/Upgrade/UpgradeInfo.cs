using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private GameObject UI;
    private GameObject mainUp;
    private GameObject mod;
    void Awake()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Upgrade/upgradeSystem");
        Debug.Log(json);
        mainUp =  UI.transform.GetChild(0).gameObject;
        mod =  UI.transform.GetChild(1).gameObject;
    }

    private void Update() {
        if(lobbyinfo.currentPage == Page.mainUp)
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.currentPage = Page.none;
                UI.SetActive(false);
            }
        }
        else if(lobbyinfo.currentPage == Page.mod)
        {
            mainUp.SetActive(false);
            mod.SetActive(true);
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.currentPage = Page.none;
                UI.SetActive(false);
            }
            else if(Keyboard.current.tabKey.wasPressedThisFrame)
            {
                lobbyinfo.currentPage = Page.mainUp;
                resetUI();
            }
        }
    }

    public void run()
    {
        resetUI();
        lobbyinfo.currentPage = Page.mainUp;
        UI.SetActive(true);
    }

    private void resetUI()
    {
        mainUp.SetActive(true);
        mod.SetActive(false);
    }
}
