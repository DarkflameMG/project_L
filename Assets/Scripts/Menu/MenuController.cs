using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private GameObject option;

    public void con()
    {
        Debug.Log("Contiue clicked...!");
    }

    public void newGame()
    {
        Debug.Log("New Game clicked...!");
        SceneManager.LoadScene("Lobby");
    }

    public void options()
    {
        Debug.Log("Options clicked...!");
        option.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exit clicked...!");
        Application.Quit();
    }
}
