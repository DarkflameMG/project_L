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
    private int x,y;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        mapSystem = GameObject.Find("SpawnMapSys").GetComponent<MapSystem>();
    }

    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        // x = mapLoc.current_x + delta_x;
        // y = mapLoc.current_y + delta_y;

        if(CantInteract())
        {
            // nothing happen
        }
        else
        {
            mapLoc.current_x = x;
            mapLoc.current_y = y;
            mapSystem.ChangeRoom(side);
        }
        return false;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().showPopup("Open");
        return true;
    }

    public bool CantInteract()
    {
        x = mapLoc.current_x + delta_x;
        y = mapLoc.current_y + delta_y;
        bool result = 0 > x || 0 > y || x > mapLoc.width-1 || y > mapLoc.hight-1;
        return result;
    }
    
}