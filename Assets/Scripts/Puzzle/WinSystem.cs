using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    [SerializeField]Transform puzzleScene;
    [SerializeField]Transform puzzleTool;
    [SerializeField]LobbyInfo mapInfo;
    private GameObject[] bulbs;
    private bool winCond = false;
    private bool isStart = false;

    public void StartGame()
    {
        bulbs = GameObject.FindGameObjectsWithTag("bulb");
        isStart = true;
    }

    private void Update() {
        if(!winCond && isStart)
        {
            CheckWinCond();
        }
    }
    public void CheckWinCond()
    {
        winCond = true;
        foreach(GameObject bulb in bulbs)
        {
            winCond = winCond && bulb.GetComponent<GateObject>().GetCurrentState();
            if(!winCond)
                break;
        }
        if(winCond)
        {
            Debug.Log("Win");
            puzzleScene.gameObject.SetActive(false);
            puzzleTool.gameObject.SetActive(false);
            mapInfo.Busy = false;
        }
    }

}
