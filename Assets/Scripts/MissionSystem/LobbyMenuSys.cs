using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMenuSys : MonoBehaviour
{
    [SerializeField]private GameObject menuUI;
    private bool toggle = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        toggle = !toggle;
        menuUI.SetActive(toggle);
    }

    public void ExitGame()
    {
        ToggleMenu();
        Debug.Log("quit game");
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
