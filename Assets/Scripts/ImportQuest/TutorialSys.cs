using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSys : MonoBehaviour
{
    [SerializeField]private GameObject tutorial1;
    [SerializeField]private GameObject tutorial2;
    [SerializeField]private GameObject tutorial3;

    public void ResetAll()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        
    }

    public void ShowUI(string puzzleName)
    {
        if(puzzleName.Equals("Puzzle1"))
        {
            tutorial1.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle2"))
        {
            tutorial2.SetActive(true);
        }
        else if(puzzleName.Equals("Same"))
        {
            tutorial3.SetActive(true);
        }
    }
}
