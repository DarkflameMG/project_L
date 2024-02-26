using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonBox : MonoBehaviour,IInteractable
{
    [SerializeField]private MonsterSO monsterSO;
    private GameObject popupSystem;
    private MapSystem mapSystem;
    private FightSys fightSys;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        mapSystem = GameObject.Find("SpawnMapSys").GetComponent<MapSystem>();
        fightSys = GameObject.Find("FightSys").GetComponent<FightSys>();
    }
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Fight!!!");
        fightSys.ConfirmReward();
        return false;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().ShowPopup("Fight");
        popupSystem.GetComponent<Popups>().ShowMonPopup();
        return true;
    }
}
