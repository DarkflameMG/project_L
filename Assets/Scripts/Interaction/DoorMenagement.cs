using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMenagement : MonoBehaviour
{
    [SerializeField]private Transform doors;
    private Doors doorFront;
    private Doors doorBack;
    private Doors doorLeft;
    private Doors doorRight;
    private bool front = true;
    private bool back = true;
    private bool left = true;
    private bool right = true;
    private void Awake() 
    {
        doorFront = doors.GetChild(0).GetComponent<Doors>();
        doorBack = doors.GetChild(1).GetComponent<Doors>();
        doorLeft = doors.GetChild(2).GetComponent<Doors>();
        doorRight = doors.GetChild(3).GetComponent<Doors>();
    }

    private void CheckDoor()
    {

    }

    public void HideDoor()
    {
        doorFront.gameObject.SetActive(front);
        doorBack.gameObject.SetActive(back);
        doorLeft.gameObject.SetActive(left);
        doorRight.gameObject.SetActive(right);
    }
}
