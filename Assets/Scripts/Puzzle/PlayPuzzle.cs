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

    public void StartPuzzle()
    {
        puzzleScene.gameObject.SetActive(true);
        puzzleTool.gameObject.SetActive(true);
        createPuzzleSys.GetComponent<CreatePuzzle>().StartGame();
        mapUI.SetActive(false);
        mapInfo.Busy = true;
    }
}
