using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonBox : MonoBehaviour,IInteractable
{
    [SerializeField]private MonsterSO monsterSO;
    private GameObject popupSystem;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
    }
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Fight!!!");
        return false;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().ShowPopup("Fight");
        return true;
    }
}
