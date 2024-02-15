using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInventorySys : MonoBehaviour
{
    [SerializeField]private GameObject inventoryUI;
    [SerializeField]private Transform keyPrefab;
    [SerializeField]private Transform keyContent;
    [SerializeField]private KeySO keySO;
    private bool inventoryState = false;

    private void Awake() {
        SpawnKey();
    }

    private void Update() {
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            ToggleUI();
        }
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
}
