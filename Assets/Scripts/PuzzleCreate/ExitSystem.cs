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

    public void ConfirmExit()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void CancelExit()
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
