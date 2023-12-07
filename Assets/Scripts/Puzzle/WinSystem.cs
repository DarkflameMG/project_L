using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSystem : MonoBehaviour
{
    [SerializeField]private Transform puzzleScene;
    [SerializeField]private Transform puzzleTool;
    [SerializeField]private LobbyInfo mapInfo;
    [SerializeField]private GameObject mapUI;
    private GameObject[] bulbs;
    private bool winCond = false;
    private bool isStart = false;
    private Button btn;

    public void Awake()
    {
        btn = GetComponent<Button>();
        bulbs = GameObject.FindGameObjectsWithTag("bulb");
        isStart = true;
        btn.onClick.AddListener(CheckWinCond);
    }

    public void CheckWinCond()
    {
        // Debug.Log("check");
        winCond = true;
        foreach(GameObject bulb in bulbs)
        {
            winCond = winCond && bulb.GetComponent<GateObject>().GetCurrentState();
            if(!winCond)
                break;
        }
        if(winCond)
        {
            // Debug.Log("Win");
            mapUI.SetActive(true);
            puzzleScene.gameObject.SetActive(false);
            puzzleTool.gameObject.SetActive(false);
            mapInfo.Busy = false;
        }
    }

}
