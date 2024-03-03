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
    [SerializeField]WinSystem winSystem;
    private Transform currentPuzzleBox;

    public void StartPuzzle(Transform puzzleBox)
    {
        winSystem.DestroyGates();
        winSystem.DestroyLines();
        StartCoroutine(GameStart(puzzleBox));
    }

    private IEnumerator GameStart(Transform puzzleBox)
    {
        yield return new WaitForSeconds(0.25f);
        currentPuzzleBox = puzzleBox;
        puzzleScene.gameObject.SetActive(true);
        puzzleTool.gameObject.SetActive(true);
        createPuzzleSys.GetComponent<CreatePuzzle>().StartGame();
        mapUI.SetActive(false);
        tabBar.SetActive(false);
        mapInfo.Busy = true;
    }   

    public void UpdateChest()
    {
        currentPuzzleBox.GetComponent<PuzzleBox>().SetInteract(false);
    }

    public void HideMap()
    {
        if(!mapInfo.Busy)
        {
            mapUI.SetActive(!mapUI.activeSelf);
        }
    }
    
}
