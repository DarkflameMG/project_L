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
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
