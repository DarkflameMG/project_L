using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour,IInteractable
{
    [SerializeField]private string _prompt;
    [SerializeField]private GameObject popupSystem;
    [SerializeField]private GameObject UpgradeSystem;
    public string interactionPrompt => _prompt;
     public bool Interact(Interactor interactor)
    {
        Debug.Log("Found job");
        changeScene();
        return true;
    }

    public bool ShowPopup()
    {
        popupSystem.GetComponent<Popups>().showPopup("Talk");
        return true;
    }

    private void changeScene()
    {
        // SceneManager.LoadScene("MissionSelect");
        UpgradeSystem.GetComponent<UpgradeInfo>().run();
    }
}
