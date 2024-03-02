using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSys : MonoBehaviour
{
    [SerializeField]private GameObject menuUI;
    [SerializeField]private Button retreat;
    [SerializeField]private DontDestroyMap dontDestroyMap;
    private bool toggle = false;
    private Button retreatBtn;

    private void Awake() {
        retreatBtn = retreat;
        retreatBtn.onClick.AddListener(Retreat);
    }

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

    private void Retreat()
    {
        ToggleMenu();
        SceneManager.LoadScene("Lobby");
        dontDestroyMap.MapToLobby();
    }

}
