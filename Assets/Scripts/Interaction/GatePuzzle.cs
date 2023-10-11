using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatePuzzle : MonoBehaviour,IInteractable
{
    [SerializeField]private string _prompt;
    [SerializeField]private GameObject popupSystem;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        ChangeScene();
        return true;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().showPopup("Enter");
        return true;
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("TestJSON");
    }
}
