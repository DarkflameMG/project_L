using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour, IInteractable
{
    [SerializeField]private string _prompt;
    [SerializeField]private Mesh open;
    [SerializeField]private Mesh close;
    private GameObject popupSystem;
    private GameObject playPuzzleSys;
    private bool canInteract = true;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        playPuzzleSys = GameObject.Find("PuzzlePlaySys");
    }
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        if(canInteract)
        {
            Debug.Log("Open");
            playPuzzleSys.GetComponent<PlayPuzzle>().StartPuzzle(this.transform);
            return true;
        }
        return false;
    }

    public bool ShowPopup()
    {
        if(canInteract)
        {
            popupSystem.GetComponent<Popups>().ShowPopup("Play");
        }
        return true;
    }

    public void SetInteract(bool data)
    {
        canInteract = data;
        if(canInteract)
        {
            GetComponent<MeshFilter>().mesh = close;
            GetComponent<MeshCollider>().sharedMesh = null;
            GetComponent<MeshCollider>().sharedMesh = close;
        }
        else
        {
            GetComponent<MeshFilter>().mesh = open;
            GetComponent<MeshCollider>().sharedMesh = null;
            GetComponent<MeshCollider>().sharedMesh = open;
        }
    }
}
