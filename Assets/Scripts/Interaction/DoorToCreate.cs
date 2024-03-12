using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToCreate : MonoBehaviour, IInteractable
{
    [SerializeField]private Popups popups;
    [SerializeField]private LobbyInfo lobbyInfo;
    [SerializeField]private GameObject toCreateUI;
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        if(lobbyInfo.Busy != true)
        {
            toCreateUI.SetActive(true);
        }
        return true;
    }

    public bool ShowPopup()
    {
        popups.ShowPopup("Open");
        return true;
    }
}
