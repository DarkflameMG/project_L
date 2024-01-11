using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField]private GameObject item;

    public GameObject GetItem()
    {
        return item;
    }
    public void SetItem(GameObject data)
    {
        item = data;
    }
}
