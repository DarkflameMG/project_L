using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour, IInteractable
{
    [SerializeField]private string _prompt;
    private GameObject popupSystem;
    private GameObject playPuzzleSys;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        playPuzzleSys = GameObject.Find("PuzzlePlaySys");
    }
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Open");
        playPuzzleSys.GetComponent<PlayPuzzle>().StartPuzzle();
        return true;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().ShowPopup("Play");
        return true;
    }
}
