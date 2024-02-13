using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPuzzle : MonoBehaviour
{
    [SerializeField]Transform puzzleScene;
    [SerializeField]Transform puzzleTool;
    [SerializeField]Transform createPuzzleSys;
    [SerializeField]LobbyInfo mapInfo;
    [SerializeField]GameObject mapUI;
    [SerializeField]GameObject tabBar;

    public void StartPuzzle()
    {
        puzzleScene.gameObject.SetActive(true);
        puzzleTool.gameObject.SetActive(true);
        createPuzzleSys.GetComponent<CreatePuzzle>().StartGame();
        mapUI.SetActive(false);
        tabBar.SetActive(false);
        mapInfo.Busy = true;
    }
}
