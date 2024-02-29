using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Job_desk : MonoBehaviour,IInteractable
{
    [SerializeField]private string _prompt;
    [SerializeField]private GameObject popupSystem;
    [SerializeField]private GameObject MissionSystem;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        // Debug.Log("Found job");
        changeScene();
        return true;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().ShowPopup("Get Mission");
        return true;
    }

    // public bool ClosePopup()
    // {
    //     popupSystem.GetComponent<Popups>().closePopup();
    //     return true;
    // }

    private void changeScene()
    {
        // SceneManager.LoadScene("MissionSelect");
        MissionSystem.GetComponent<MissionSelect>().Run();
    }
}
