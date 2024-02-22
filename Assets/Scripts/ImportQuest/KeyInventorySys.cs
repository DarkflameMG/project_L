using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyInventorySys : MonoBehaviour
{
    [SerializeField]private GameObject inventoryUI;
    [SerializeField]private Transform keyPrefab;
    [SerializeField]private Transform keyContent;
    [SerializeField]private KeySO keySO;
    [SerializeField]private Transform rewardPoint;
    private bool inventoryState = false;
    private Color32[] colors;
    int index = 0;

    private void Awake() {
        SpawnKey();
        SetColors();
    }

    private void Update() {
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            ToggleUI();
        }
    }

    private void SetColors()
    {
        colors = new Color32[12];
        colors[0] = new Color32(255,255,255,255);
        colors[1] = new Color32(255,0,0,255);
        colors[2] = new Color32(246,255,0,255);
        colors[3] = new Color32(70,255,0,255);
        colors[4] = new Color32(0,255,255,255);
        colors[5] = new Color32(0,56,255,255);
        colors[6] = new Color32(155,0,255,255);
        colors[7] = new Color32(255,0,255,255);
        colors[8] = new Color32(255,0,154,255);
        colors[9] = new Color32(80,80,80,255);
        colors[10] = new Color32(255,90,128,255);
        colors[11] = new Color32(6,126,0,255);
    }

    public void ToggleUI()
    {
        inventoryState = !inventoryState;
        inventoryUI.SetActive(inventoryState);
    }

    public void AddNewKey(string name)
    {
        if(!keySO.keys.Contains(name))
        {
            keySO.keys.Add(name);
            
            Transform key = Instantiate(keyPrefab,keyContent);
            key.Find("text").GetComponent<TMP_Text>().text = name;
            key.Find("key").GetComponent<Image>().color = colors[index];
            Instantiate(key,rewardPoint);

            keySO.color.Add(colors[index]);
            index = (index+1)%12;
            keySO.currentIndex = index;
        }
    }

    private void SpawnKey()
    {
        foreach(string keyS in keySO.keys)
        {
            Transform key = Instantiate(keyPrefab,keyContent);
            key.Find("text").GetComponent<TMP_Text>().text = keyS;
        }
    }

    public void SetIndex()
    {
        index = keySO.currentIndex;
    }

}
