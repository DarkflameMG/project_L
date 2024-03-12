using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSystem : MonoBehaviour
{
    [SerializeField]private GameObject exitMenu;
    [SerializeField]private GameObject exitMenuLog;
    [SerializeField]private GameObject exitMainMenu;

    public void ShowExitMenu()
    {
        if(exitMenu != null)
        {
            exitMenu.SetActive(true);
        }
        if(exitMenuLog != null)
        {
            exitMenuLog.SetActive(true);
        }
        if(exitMainMenu != null)
        {
            exitMainMenu.SetActive(true);
        }
    }

    public void ToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void ToMap()
    {
        SceneManager.LoadScene("CreateMap");
    }

    public void ToPuzzle()
    {
        SceneManager.LoadScene("CreatePuzzle");
    }

    public void CancelMenu()
    {
        if(exitMenu != null)
        {
            exitMenu.SetActive(false);
        }
        if(exitMenuLog != null)
        {
            exitMenuLog.SetActive(false);
        }
        if(exitMainMenu != null)
        {
            exitMainMenu.SetActive(false);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowExitMenu();
        }
    }
}
