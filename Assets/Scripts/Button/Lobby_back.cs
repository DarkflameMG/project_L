using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Lobby_back : MonoBehaviour
{
    private void Update() {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("esc");
            changeScene();
        }
    }

    private void changeScene()
    {
        SceneManager.LoadScene("Lobby");
    }
}
