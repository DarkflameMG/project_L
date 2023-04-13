using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissionSelect : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyinfo;
    [SerializeField]private GameObject UI;
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
    }

    public void run()
    {
        lobbyinfo.isMissionSelect = true;
        UI.SetActive(true);
    }
}
