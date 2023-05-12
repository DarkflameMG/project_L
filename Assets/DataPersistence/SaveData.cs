using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveData : MonoBehaviour
{

    public Inventory inventory = new Inventory();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }

    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath+ "/InventoryData.json";
        Debug.Log("FilePath = \"" + filePath + "\"");
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Save Complete...!!");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("Load Data Complete...!!");
    }
}

[System.Serializable]
public class Inventory
{
    public int goldCoins;
    public bool isFull;
    public List<Item> items = new List<Item>();
}

[System.Serializable]
public class Item
{
    public string name;
    public string description;
}
