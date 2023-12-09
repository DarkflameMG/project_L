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
    [SerializeField]private Transform lines;
    [SerializeField]private Transform gates;
    private bool winCond = false;
    private bool isStart = false;
    private bool isPlay = true;
    private Button btn;

    public void Awake()
    {
        btn = GetComponent<Button>();
        // bulbs = gates.fin
        isStart = true;
        btn.onClick.AddListener(CheckWinCond);
    }

    public void CheckWinCond()
    {
        // Debug.Log(bulbs.Length);
        // winCond = true;
        // foreach(GameObject bulb in bulbs)
        // {
        //     // Debug.Log("11111");
        //     Debug.Log(bulb.GetComponent<GateObject>().GetCurrentState());
        //     // winCond = winCond && bulb.GetComponent<GateObject>().GetCurrentState();
        //     // if(!winCond)
        //     //     break;
        // }
        // if(winCond)
        // {
        //     // Debug.Log("Win");
        //     mapUI.SetActive(true);
        //     puzzleScene.gameObject.SetActive(false);
        //     puzzleTool.gameObject.SetActive(false);
        //     mapInfo.Busy = false;
        // }

        int childCount = lines.childCount;
        for(int i=0;i<childCount;i++)
        {
            Transform line = lines.GetChild(i);
            if(isPlay)
            {
                line.GetComponent<PowerLine2>().RunLine();
            }
            else
            {
                line.GetComponent<PowerLine2>().StopLine();
            }
        }

        isPlay = !isPlay;
    }

}
