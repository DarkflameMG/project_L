using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonBoss : MonoBehaviour, IInteractable
{
    [SerializeField]private string _prompt;
    private GameObject popupSystem;
    private GameObject dugenoClearSys;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        dugenoClearSys = GameObject.Find("DugeonClearSys");
    }

    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log("fight");
        dugenoClearSys.GetComponent<DungeonClearSystem>().MissionClear();
        return true;
    }

    public bool ShowPopup()
    {
        Debug.Log("show");
        popupSystem.GetComponent<Popups>().ShowPopup("Fight");
        return true;
    }
}
