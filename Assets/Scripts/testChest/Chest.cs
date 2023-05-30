using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    GameObject chest_box;

    public void Exit()
    {
        chest_box.SetActive(false);
    }

    public void open_box()
    {
        chest_box.SetActive(true);
    }
}
