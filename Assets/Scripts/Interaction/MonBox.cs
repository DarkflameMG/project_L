using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonBox : MonoBehaviour,IInteractable
{
    [SerializeField]private MonsterSO monsterSO;
    private GameObject popupSystem;
    private MapSystem mapSystem;
    private FightSys fightSys;
    private DontDestroyMap dontDestroyMap;
    private void Awake() {
        popupSystem = GameObject.Find("PopupSystem");
        mapSystem = GameObject.Find("SpawnMapSys").GetComponent<MapSystem>();
        fightSys = GameObject.Find("FightSys").GetComponent<FightSys>();
        dontDestroyMap = GameObject.Find("mapControlScript").GetComponent<DontDestroyMap>();
    }
    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Fight!!!");
        MonsterDetail monsterDetail = mapSystem.GetCurrentRoomDetail().monster;
        monsterSO.monsterName = monsterDetail.name;
        monsterSO.hp = monsterDetail.hp;
        monsterSO.attack = monsterDetail.atk;
        fightSys.ConfirmReward();

        SceneManager.LoadScene("CardTernBase");
        dontDestroyMap.MapToFight();
        return false;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().ShowPopup("Fight");
        popupSystem.GetComponent<Popups>().ShowMonPopup();
        return true;
    }
}
