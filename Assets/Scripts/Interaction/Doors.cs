using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour,IInteractable
{
    [SerializeField]private MapLocSO mapLoc;
    [SerializeField]private int delta_x;
    [SerializeField]private int delta_y;
    private GameObject popupSystem;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
    }

    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        mapLoc.current_x += delta_x;
        mapLoc.current_y += delta_y;
        return true;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().showPopup("Open");
        return true;
    }
}