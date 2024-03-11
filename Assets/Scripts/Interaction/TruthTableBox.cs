using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruthTableBox : MonoBehaviour, IInteractable
{
    [SerializeField]private string _prompt;
    [SerializeField]private LobbyInfo lobbyInfo;
    private GameObject popupSystem;
    private GameObject playFinalPuzzleSys;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        playFinalPuzzleSys = GameObject.Find("FinalPuzzlePlaySys");
    }
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        // Debug.Log("Open");
        if(lobbyInfo.Busy != true)
        {
            playFinalPuzzleSys.GetComponent<PlayFinalPuzzle>().StartPuzzle();
            return true;
        }
        return false;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().ShowPopup("Play");
        return true;
    }
}
