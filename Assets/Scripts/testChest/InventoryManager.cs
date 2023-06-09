using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemForTest> items = new List<ItemForTest>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    private void Awake()
    {
        Instance = this; 
    }

    public void Add(ItemForTest item)
    {
        items.Add(item);
    }

    public void Remove(ItemForTest item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        //clean content before open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }


        foreach(var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var objName = obj.transform.Find("ItemName").GetComponent<Text>();
            var objIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            objName.text = item.itemName;
            objIcon.sprite = item.icon;
        }
    }
}
