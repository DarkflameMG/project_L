using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    public TMP_Text Name1;

    [SerializeField]
    public TMP_Text Name2;

    [SerializeField]
    public TMP_Text Name3;

    [SerializeField]
    public TMP_Text Name4;

    [SerializeField]
    public TMP_Text Gold1;

    [SerializeField]
    public TMP_Text Gold2;

    [SerializeField]
    public TMP_Text Gold3;

    [SerializeField]
    public TMP_Text Gold4;

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;


    public PYData playerData1 = new PYData();
    public PYData playerData2 = new PYData();
    public PYData playerData3 = new PYData();
    public PYData playerData4 = new PYData();

    private void Awake()
    {

        //load slot 1
        try
        {
            string filePath1 = Application.persistentDataPath + "/PlayerData1.json";
            string PlayerDataJson1 = System.IO.File.ReadAllText(filePath1);
            playerData1 = JsonUtility.FromJson<PYData>(PlayerDataJson1);
            Name1.text = playerData1._name;
            Gold1.text = playerData1._inventory.goldCoins.ToString();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            Debug.Log("Not save data file....");
            Name1.text = "No data";
            Gold1.text = "";
            // btn1.enabled = false;
        }

        //load slot 2
        try
        {
            string filePath2 = Application.persistentDataPath + "/PlayerData2.json";
            string PlayerDataJson2 = System.IO.File.ReadAllText(filePath2);
            playerData2 = JsonUtility.FromJson<PYData>(PlayerDataJson2);
            Name2.text = playerData2._name;
            Gold2.text = playerData2._inventory.goldCoins.ToString();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            Debug.Log("Not save data file....");
            Name2.text = "No data";
            Gold2.text = "";
            // btn2.enabled = false;
        }

        //load slot 3
        try
        {
            string filePath3 = Application.persistentDataPath + "/PlayerData3.json";
            string PlayerDataJson3 = System.IO.File.ReadAllText(filePath3);
            playerData3 = JsonUtility.FromJson<PYData>(PlayerDataJson3);
            Name3.text = playerData3._name;
            Gold3.text = playerData3._inventory.goldCoins.ToString();
        }

        catch (Exception e)
        {
            Debug.LogException(e);
            Debug.Log("Not save data file....");
            Name3.text = "No data";
            Gold3.text = "";
            // btn3.enabled = false;
        }

        //load slot 4
        try
        {
            string filePath4 = Application.persistentDataPath + "/PlayerData4.json";
            string PlayerDataJson4 = System.IO.File.ReadAllText(filePath4);
            playerData4 = JsonUtility.FromJson<PYData>(PlayerDataJson4);
            Name4.text = playerData4._name;
            Gold4.text = playerData4._inventory.goldCoins.ToString();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            Debug.Log("Not save data file....");
            Name4.text = "No data";
            Gold4.text = "";
            // btn4.enabled = false;
        }

        
        
       
        
    }

}
