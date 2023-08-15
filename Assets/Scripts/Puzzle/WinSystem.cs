using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    private GameObject[] bulbs;
    private bool winCond = false;

    public void StartGame()
    {
        bulbs = GameObject.FindGameObjectsWithTag("bulb");
        Debug.Log(bulbs.Length);
    }

    private void Update() {
        if(!winCond)
        {
            CheckWinCond();
        }
    }
    public void CheckWinCond()
    {
        winCond = true;
        foreach(GameObject bulb in bulbs)
        {
            winCond = winCond && bulb.GetComponent<GateObject>().GetCurrentState();
            if(!winCond)
                break;
        }
        if(winCond)
        {
            Debug.Log("Win");
        }
    }

}
