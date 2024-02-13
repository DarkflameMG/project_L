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
    private bool inventoryState = false;
    private List<string> keys;

    private void Awake() {
        keys = new List<string>();
    }

    private void Update() {
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            ToggleUI();
        }
    }

    private void ToggleUI()
    {
        inventoryState = !inventoryState;
        inventoryUI.SetActive(inventoryState);
    }

    public void AddNewKey(string name)
    {
        if(!keys.Contains(name))
        {
            keys.Add(name);
            Transform key = Instantiate(keyPrefab,keyContent);
            key.Find("text").GetComponent<TMP_Text>().text = name;
        }
    }
}
