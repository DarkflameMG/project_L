using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{

    [SerializeField]
    public PlayerData py;
    [SerializeField]
    public bool lockAwake = false;

    public PYData playerData = new PYData();

    private void Awake()
    {
        if(!lockAwake)
        {
            py.ReSetData();
        }
    }

    private void Update()
    {
        
        if(py.Inventorys != null)
        {
            py.Inventorys.Update();
        }
        
        //Save data when press S from keyboard.
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     SaveToJson();
        // }

    }

    public void NewGameToJson(int slot,TMP_InputField name)
    {
        PlayerData newGame = new PlayerData();
        newGame.SlotNumber = slot;
        newGame.Name = name.text;
        string PlayerDataJson = JsonUtility.ToJson(newGame);
        string filePath = Application.persistentDataPath+ "/PlayerData" + slot + ".json";
        //string filePath = Application.persistentDataPath + "/PlayerData2.json";
        Debug.Log("FilePath = \"" + filePath + "\"");
        System.IO.File.WriteAllText(filePath, PlayerDataJson);
        Debug.Log("Save Data to slot " + slot + " Complete...!!");

        LoadFromJson(slot);
    }

    public void SaveToJson()
    {
        Debug.Log("StartSave");
        string PlayerDataJson = JsonUtility.ToJson(py);
        string filePath = Application.persistentDataPath+ "/PlayerData" + py.SlotNumber + ".json";
        //string filePath = Application.persistentDataPath + "/PlayerData2.json";
        Debug.Log("FilePath = \"" + filePath + "\"");
        System.IO.File.WriteAllText(filePath, PlayerDataJson);
        Debug.Log("Save Data to slot " + py.SlotNumber + " Complete...!!");
    }
    public void SaveToJsonV2(PlayerData data)
    {
        Debug.Log("StartSave");
        string PlayerDataJson = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath+ "/PlayerData" + data.SlotNumber + ".json";
        //string filePath = Application.persistentDataPath + "/PlayerData2.json";
        Debug.Log("FilePath = \"" + filePath + "\"");
        System.IO.File.WriteAllText(filePath, PlayerDataJson);
        Debug.Log("Save Data to slot " + data.SlotNumber + " Complete...!!");
    }


    public void LoadFromJson(int slot)
    {
        // Debug.Log("Loaddddddd");
        string filePath = Application.persistentDataPath + "/PlayerData" + slot + ".json";
        string PlayerDataJson = System.IO.File.ReadAllText(filePath);
        Debug.Log(PlayerDataJson);

        // playerData = JsonUtility.FromJson<PYData>(PlayerDataJson);
        playerData = JsonConvert.DeserializeObject<PYData>(PlayerDataJson);

        Debug.Log(playerData.puzzleCompleted);

        py.SlotNumber = playerData._slotNumber;
        py.Name = playerData._name;
        py.Inventorys = playerData._inventory;
        py.Position = playerData._position;
        py.puzzleCompleted = playerData.puzzleCompleted;

        Debug.Log("Load Data from slot " + slot + "  Complete...!!");
        SceneManager.LoadScene("Lobby");
    }

    


    //Menu button

    [SerializeField]
    private GameObject LoadFile;

    [SerializeField]
    private GameObject NewFile;

    [SerializeField]
    public GameObject confirmBox;

    [SerializeField]
    public GameObject confirmBox2;

    [SerializeField]
    public TMP_InputField Name;

    public int dataSlot;

    public void showConfirmBox(bool op)
    {
        confirmBox.SetActive(op);
    }

    public void showConfirmBox2(bool op)
    {
        confirmBox2.SetActive(op);

    }

    public void yesButton()
    {
        showConfirmBox(false);
        LoadFromJson(this.dataSlot);
    }

    public void yesToNewButton()
    {
        showConfirmBox2(false);
        NewGameToJson(this.dataSlot,Name);
        SceneManager.LoadScene("Lobby");
    }

    public void noButton()
    {
        showConfirmBox(false);
        showConfirmBox2(false);
    }

    public void LoadData1()
    {
        Debug.Log("Save 1 is Loading...!!");
        showConfirmBox(true);
        dataSlot = 1;
    }

    public void LoadData2()
    {
        Debug.Log("Save 2 is Loading...!!");
        showConfirmBox(true);
        dataSlot = 2;
    }

    public void LoadData3()
    {
        Debug.Log("Save 3 is Loading...!!");
        showConfirmBox(true);
        dataSlot = 3;
    }

    public void LoadData4()
    {
        Debug.Log("Save 4 is Loading...!!");
        showConfirmBox(true);
        dataSlot = 4;
    }

    public void NewData1()
    {
        Debug.Log("New Save 1...!!");
        showConfirmBox2(true);
        dataSlot = 1;
    }

    public void NewData2()
    {
        Debug.Log("New Save 2...!!");
        showConfirmBox2(true);
        dataSlot = 2;
    }

    public void NewData3()
    {
        Debug.Log("New Save 3...!!");
        showConfirmBox2(true);
        dataSlot = 3;
    }
    
    public void NewData4()
    {
        Debug.Log("New Save 44...!!");
        showConfirmBox2(true);
        dataSlot = 4;
    }

    public void exit()
    {
        LoadFile.SetActive(false);
    }

    public void exit2()
    {
        NewFile.SetActive(false);
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
    public List<string> puzzleCompleted;
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
