using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFinalPuzzle : MonoBehaviour
{
    [SerializeField]Transform finalPuzzleScene;
    [SerializeField]LobbyInfo mapInfo;
    [SerializeField]GameObject mapUI;
    [SerializeField]GameObject canvasUI;
    [SerializeField]SetTableSys setTableSys;

    public void StartPuzzle()
    {
        finalPuzzleScene.gameObject.SetActive(true);
        mapUI.SetActive(false);
        canvasUI.SetActive(false);
        mapInfo.Busy = true;

        setTableSys.SetTable();
    }
}