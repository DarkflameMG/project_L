using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSys : MonoBehaviour
{
    [SerializeField]private GameObject tutorial1;
    [SerializeField]private GameObject tutorial2;
    [SerializeField]private GameObject tutorial3;
    [SerializeField]private GameObject notIntro;
    [SerializeField]private GameObject andIntro;
    [SerializeField]private GameObject orIntro;
    [SerializeField]private GameObject nandIntro;
    [SerializeField]private GameObject norIntro;
    [SerializeField]private GameObject xorXnorIntro;
    [SerializeField]private GameObject halfAdderIntro;
    [SerializeField]private GameObject fullAdderIntro;

    public void ResetAll()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        notIntro.SetActive(false);
        andIntro.SetActive(false);
        orIntro.SetActive(false);
        nandIntro.SetActive(false);
        norIntro.SetActive(false);
        xorXnorIntro.SetActive(false);
        halfAdderIntro.SetActive(false);
        fullAdderIntro.SetActive(false);
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
        else if(puzzleName.Equals("Table1"))
        {
            tutorial3.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle3"))
        {
            notIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle5"))
        {
            andIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle7"))
        {
            orIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle8"))
        {
            nandIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle9"))
        {
            norIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle11"))
        {
            xorXnorIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle12"))
        {
            halfAdderIntro.SetActive(true);
        }
        else if(puzzleName.Equals("Puzzle13"))
        {
            fullAdderIntro.SetActive(true);
        }
    }
}
