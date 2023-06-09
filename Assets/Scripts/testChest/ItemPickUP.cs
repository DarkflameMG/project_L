using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUP : MonoBehaviour
{
    public ItemForTest Item;

    public void PickUp()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Debug.Log("Click Item!!!");
        PickUp();
    }
}
