using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour,IInteractable
{
    [SerializeField]private MapLocSO mapLoc;
    [SerializeField]private int delta_x;
    [SerializeField]private int delta_y;
    [SerializeField]private RoomSide side;
    private GameObject popupSystem;
    private MapSystem mapSystem;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        mapSystem = GameObject.Find("SpawnMapSys").GetComponent<MapSystem>();
    }

    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        int x = mapLoc.current_x + delta_x;
        int y = mapLoc.current_y + delta_y;

        if(0 > x || 0 > y || x > mapLoc.max_x-1 || y > mapLoc.max_y-1)
        {
            // nothing happen
        }
        else
        {
            mapLoc.current_x = x;
            mapLoc.current_y = y;
            mapSystem.changeRoom(side);
        }
        return false;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().showPopup("Open");
        return true;
    }
    
}