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
    [SerializeField]GameObject tabBar;
    [SerializeField]Transform spawnGate;
    [SerializeField]Transform spawnLine; 
    [SerializeField]MapSystem mapSystem;
    [SerializeField]TutorialSys tutorialSys;
    [SerializeField]private LimitFinalGateSys limitFinalGateSys;

    public void StartPuzzle()
    {
        finalPuzzleScene.gameObject.SetActive(true);
        mapUI.SetActive(false);
        canvasUI.SetActive(false);
        tabBar.SetActive(false);
        mapInfo.Busy = true;

        RoomDetail roomDetail = mapSystem.GetCurrentRoomDetail();
        tutorialSys.ShowUI(roomDetail.puzzleName);
        setTableSys.SetTable();

        limitFinalGateSys.SetStartNum();
    }

    public void Escape()
    {
        finalPuzzleScene.gameObject.SetActive(false);
        mapUI.SetActive(true);
        canvasUI.SetActive(true);
        tabBar.SetActive(true);
        mapInfo.Busy = false;
        DeletedAll();
    }

    public void DeletedAll()
    {
        int countGate = spawnGate.childCount;
        for(int i=0;i<countGate;i++)
        {
            GameObject gate = spawnGate.GetChild(i).gameObject;
            Destroy(gate);
        }

        int countLine = spawnLine.childCount;
        for(int i=0;i<countLine;i++)
        {
            GameObject line = spawnLine.GetChild(i).gameObject;
            Destroy(line);
        }

        limitFinalGateSys.SetStartNum();
    }
}
