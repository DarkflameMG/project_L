using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePuzzlePageSys : MonoBehaviour
{
    [SerializeField]private GameObject createPuzzle;
    [SerializeField]private GameObject viewLog;
    [SerializeField]private GameObject createTable;
    [SerializeField]private GameObject mainPage;
    [SerializeField]private GameObject exitMenuCreate;
    [SerializeField]private GameObject exitMenuTable;
    private GameObject curerntUI;
    private void Awake() {
        mainPage.SetActive(true);
        curerntUI = mainPage;
        createPuzzle.SetActive(false);
        createTable.SetActive(false);
        viewLog.SetActive(false);
        exitMenuCreate.SetActive(false);
        exitMenuTable.SetActive(false);
    }

    public void ShowCreate()
    {
        createPuzzle.SetActive(true);
        curerntUI.SetActive(false);
        curerntUI = createPuzzle;
        exitMenuTable.SetActive(false);
        exitMenuCreate.SetActive(false);
    }

    public void ShowLog()
    {
        viewLog.SetActive(true);
        curerntUI.SetActive(false);
        curerntUI = viewLog;
        exitMenuCreate.SetActive(false);
        exitMenuTable.SetActive(false);
    }

    public void ShowTableCreate()
    {
        createTable.SetActive(true);
        curerntUI.SetActive(false);
        curerntUI = createTable;
        exitMenuTable.SetActive(false);
        exitMenuCreate.SetActive(false);
    }
}
