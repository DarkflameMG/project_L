using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveData : MonoBehaviour
{

    [SerializeField]
    public PlayerData py;

    public PYData playerData = new PYData();

    private void Awake()
    {
        py.reSet();
    }

    private void Update()
    {
        
        if(py.Inventorys != null)
        {
            py.Inventorys.Update();
        }
        
        //Save data when press S from keyboard.
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }

    }

    public void SaveToJson()
    {
        string PlayerDataJson = JsonUtility.ToJson(py);
        string filePath = Application.persistentDataPath+ "/PlayerData" + py.SlotNumber + ".json";
        //string filePath = Application.persistentDataPath + "/PlayerData2.json";
        Debug.Log("FilePath = \"" + filePath + "\"");
        System.IO.File.WriteAllText(filePath, PlayerDataJson);
        Debug.Log("Save Data to slot " + py.SlotNumber + " Complete...!!");
    }


    public void LoadFromJson(int slot)
    {
        string filePath = Application.persistentDataPath + "/PlayerData" + slot + ".json";
        string PlayerDataJson = System.IO.File.ReadAllText(filePath);

        playerData = JsonUtility.FromJson<PYData>(PlayerDataJson);


        py.SlotNumber = playerData._slotNumber;
        py.Name = playerData._name;
        py.Inventorys = playerData._inventory;
        py.Position = playerData._position;

        Debug.Log("Load Data from slot " + slot + "  Complete...!!");
    }


    //Menu button

    [SerializeField]
    private GameObject LoadFile;

    public void LoadData1()
    {
        Debug.Log("Save 1 is Loading...!!");
        LoadFromJson(1);
    }

    public void LoadData2()
    {
        Debug.Log("Save 2 is Loading...!!");
        LoadFromJson(2);
    }

    public void LoadData3()
    {
        Debug.Log("Save 3 is Loading...!!");
        LoadFromJson(3);
    }

    public void LoadData4()
    {
        Debug.Log("Save 4 is Loading...!!");
        LoadFromJson(4);
    }

    public void exit()
    {
        LoadFile.SetActive(false);
    }
}


//Data for Temp to ScriptableObject

[System.Serializable]
public class PYData
{
    public int _slotNumber;
    public string _name;
    public Vector3 _position = new Vector3();
    public Inventory _inventory = new Inventory();
}

[System.Serializable]
public class Inventory
{
    public int goldCoins;
    public bool isFull;
    public List<Item> items = new List<Item>();

    public void Update()
    {
        if (items.Count >= 20)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public string description;
}
