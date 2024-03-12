using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSelectionSys : MonoBehaviour
{
    [SerializeField]private LobbyInfo lobbyInfo;
    [SerializeField]private GameObject toCreateUI;

    public void CloseUI()
    {
        lobbyInfo.Busy = false;
        toCreateUI.SetActive(false);
    }

    public void ToCreateMap()
    {
        SceneManager.LoadScene("CreateMap");
    }

    public void ToPuzzleMap()
    {
        SceneManager.LoadScene("CreatePuzzle");
    }
}
