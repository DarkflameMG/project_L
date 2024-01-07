using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSystem : MonoBehaviour
{
    [SerializeField]private GameObject puzzleScene;
    [SerializeField]private GameObject puzzleTool;
    [SerializeField]private LobbyInfo mapInfo;
    [SerializeField]private GameObject mapUI;
    [SerializeField]private Transform lines;
    [SerializeField]private Transform gates;

    [SerializeField]private GameObject playIcon;
    [SerializeField]private GameObject pauseIcon;
    [SerializeField]private GameObject exitIcon;
    private List<PowerLine2> wrongLines;
    private bool winCond = true;
    private bool isWin = false;
    private bool isPlay = true;
    private Button btn;
    private GameObject currentIcon;
    private List<GameObject> bulbs;

    public void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TriggleCheck);
        currentIcon = playIcon;
    }
    public void SetBulbs(List<GameObject> data)
    {
        bulbs = data;
    }

    public void TriggleCheck()
    {
        // Debug.Log(winCond);
        // Debug.Log(isWin);
        // Debug.Log(isPlay);
        if(!isWin)
        {
            CheckWinCond();
        }
        else
        {
            Exit();
        }
        ChangeIcon();
      
    }

    private void DestroyGates()
    {
        int gateCount = gates.childCount;
        for(int i=0;i<gateCount;i++)
        {
            GameObject gate = gates.GetChild(i).gameObject;
            Destroy(gate);
        }
    }
    private void DestroyLines()
    {
        int lineCount = lines.childCount;
        for(int i=0;i<lineCount;i++)
        {
            GameObject line = lines.GetChild(i).gameObject;
            Destroy(line);
        }
    }

    private void Exit()
    {
        DestroyGates();
        DestroyLines();
        puzzleScene.SetActive(false);
        puzzleTool.SetActive(false);
        mapInfo.Busy = false;
    }
    private void CheckWinCond()
    {
        int childCount = lines.childCount;
        for(int i=0;i<childCount;i++)
        {
            PowerLine2 line = lines.GetChild(i).GetComponent<PowerLine2>();
            if(isPlay)
            {
                line.RunLine();
                // if(line.GetExpectBool() != line.GetCurrentState())
                // {
                //     winCond = false;
                //     wrongLines.Add(line);
                // }
            }
            else
            {
                line.StopLine();
            }
        }
        
        StartCoroutine(CheckBulbs());
        // if(winCond && isPlay)
        // {
        //     isWin = true;
        //     // ChangeIcon();
        // }
        // // else if(isPlay)
        // // {
        // //     ChangeIcon();
        // // }

        // isPlay = !isPlay;
    }

    IEnumerator CheckBulbs()
    {
        yield return new WaitForSeconds(0.1f);
        winCond = true;
        foreach(GameObject bulb in bulbs)
        {
            Debug.Log(bulb.GetComponent<GateObject>().GetCurrentState());
            if(!bulb.GetComponent<GateObject>().GetCurrentState())
            {
                winCond = false;
                break;
            }
        }

        if(winCond && isPlay)
        {
            isWin = true;
            // ChangeIcon();
        }
        // else if(isPlay)
        // {
        //     ChangeIcon();
        // }

        isPlay = !isPlay;
    }

    private void ChangeIcon()
    {
        currentIcon.SetActive(false);
        if(winCond)
        {
            exitIcon.SetActive(true);
            currentIcon = exitIcon;
        }
        else if(isPlay)
        {
            playIcon.SetActive(true);
            currentIcon = playIcon;
        }
        else
        {
            pauseIcon.SetActive(true);
            currentIcon = pauseIcon;
        }
    }

    public void ReState()
    {
        currentIcon.SetActive(false);
        currentIcon = playIcon;
        playIcon.SetActive(true);
        winCond = true;
        isWin = false;
        isPlay = true;
        wrongLines = new List<PowerLine2>();
    }
}
