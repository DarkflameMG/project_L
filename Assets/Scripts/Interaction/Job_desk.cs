using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Job_desk : MonoBehaviour,IInteractable
{
    [SerializeField] private string _prompt;
    public string interactionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Found job");
        changeScene();
        return true;
    }

    private void changeScene()
    {
        SceneManager.LoadScene("MissionSelect");
    }
}
