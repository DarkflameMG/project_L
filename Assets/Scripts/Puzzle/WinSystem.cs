using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]private GameObject statusUI;
    [SerializeField]private TMP_Text statusText;
    [SerializeField]private GameObject tabBar;
    [SerializeField]private KeyInventorySys keyInventorySys;
    [SerializeField]private MapSystem mapSystem;
    [SerializeField]private PlayPuzzle playPuzzle;
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
    private void Update() {
        // ChangeIcon();
    }

    public void TriggleCheck()
    {
        if(!isWin)
        {
            CheckWinCond();
        }
        else
        {
            Exit();
        }
    }

    private void DestroyGates()
    {
        int gateCount = gates.childCount;
        for(int i=0;i<gateCount;i++)
        {
            GameObject gate = gates.GetChild(i).gameObject;
            Destroy(gate);
        }
        statusUI.SetActive(false);
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
        mapUI.SetActive(true);
        tabBar.SetActive(true);
        mapInfo.Busy = false;

        RoomDetail roomDetail = mapSystem.GetCurrentRoomDetail();
        keyInventorySys.AddNewKey(roomDetail.puzzleName);
        playPuzzle.UpdateChest();
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
            }
            else
            {
                line.StopLine();
            }
        }
        
        StartCoroutine(CheckBulbs());
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
        }
        isPlay = !isPlay;
        ChangeIcon();
    }

    private void ChangeIcon()
    {
        currentIcon.SetActive(false);
        if(isWin)
        {
            exitIcon.SetActive(true);
            currentIcon = exitIcon;

            statusUI.SetActive(true);
            statusText.text = "Pass";
        }
        else if(isPlay)
        {
            playIcon.SetActive(true);
            currentIcon = playIcon;

            statusUI.SetActive(false);
        }
        else
        {
            pauseIcon.SetActive(true);
            currentIcon = pauseIcon;

            statusUI.SetActive(true);
            statusText.text = "Fail";
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
        // wrongLines = new List<PowerLine2>();
    }
}
