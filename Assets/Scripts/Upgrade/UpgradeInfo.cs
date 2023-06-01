using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private GameObject UI;
    void Awake()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Upgrade/upgradeSystem");
        Debug.Log(json);
    }

    private void Update() {
        if(lobbyinfo.currentPage == Page.mainUp)
        {
            if(Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                lobbyinfo.Busy = false;
                lobbyinfo.currentPage = Page.none;
                Debug.Log("xxx");
                UI.SetActive(false);
            }
        }
    }

    public void run()
    {
        lobbyinfo.currentPage = Page.mainUp;
        UI.SetActive(true);
    }
}
