using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSystem : MonoBehaviour
{
    [SerializeField]private GameObject exitMenu;

    public void ShowExitMenu()
    {
        exitMenu.SetActive(true);
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
        exitMenu.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowExitMenu();
        }
    }
}
