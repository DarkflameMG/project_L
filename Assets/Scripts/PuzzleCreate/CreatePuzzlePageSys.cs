using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePuzzlePageSys : MonoBehaviour
{
    [SerializeField]private GameObject createPuzzle;
    [SerializeField]private GameObject viewLog;
    [SerializeField]private GameObject mainPage;
    [SerializeField]private GameObject exitMenuCreate;
    [SerializeField]private GameObject exitMenuLog;
    private GameObject curerntUI;
    private void Awake() {
        mainPage.SetActive(true);
        curerntUI = mainPage;
        createPuzzle.SetActive(false);
        viewLog.SetActive(false);
        exitMenuCreate.SetActive(false);
        exitMenuLog.SetActive(false);
    }

    public void ShowCreate()
    {
        createPuzzle.SetActive(true);
        curerntUI.SetActive(false);
        curerntUI = createPuzzle;
        exitMenuLog.SetActive(false);
        exitMenuCreate.SetActive(false);
    }

    public void ShowLog()
    {
        viewLog.SetActive(true);
        curerntUI.SetActive(false);
        curerntUI = viewLog;
        exitMenuCreate.SetActive(false);
        exitMenuLog.SetActive(false);
    }
}
