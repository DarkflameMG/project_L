using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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


    public PYData playerData1 = new PYData();
    public PYData playerData2 = new PYData();
    public PYData playerData3 = new PYData();
    public PYData playerData4 = new PYData();

    private void Awake()
    {
        try
        {
            string filePath1 = Application.persistentDataPath + "/PlayerData1.json";
            string filePath2 = Application.persistentDataPath + "/PlayerData2.json";
            string filePath3 = Application.persistentDataPath + "/PlayerData3.json";
            string filePath4 = Application.persistentDataPath + "/PlayerData4.json";

            string PlayerDataJson1 = System.IO.File.ReadAllText(filePath1);
            string PlayerDataJson2 = System.IO.File.ReadAllText(filePath2);
            string PlayerDataJson3 = System.IO.File.ReadAllText(filePath3);
            string PlayerDataJson4 = System.IO.File.ReadAllText(filePath4);

            playerData1 = JsonUtility.FromJson<PYData>(PlayerDataJson1);
            playerData2 = JsonUtility.FromJson<PYData>(PlayerDataJson2);
            playerData3 = JsonUtility.FromJson<PYData>(PlayerDataJson3);
            playerData4 = JsonUtility.FromJson<PYData>(PlayerDataJson4);

            Name1.text = playerData1._name;
            Name2.text= playerData2._name;
            Name3.text= playerData3._name;
            Name4.text= playerData4._name;

            Gold1.text = playerData1._inventory.goldCoins.ToString();
            Gold2.text = playerData2._inventory.goldCoins.ToString();
            Gold3.text = playerData3._inventory.goldCoins.ToString();
            Gold4.text = playerData4._inventory.goldCoins.ToString();


        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

}
