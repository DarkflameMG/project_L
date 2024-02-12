using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPuzzleKey : MonoBehaviour
{
    private AddDoorKeySys addDoorKeySys;
    private Button btn;
    private void Awake() {
        addDoorKeySys = GameObject.Find("AddDoorKeySys").GetComponent<AddDoorKeySys>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetCurrentKey);
    }

    private void SetCurrentKey()
    {
        addDoorKeySys.SetDoorKey(name);
    }   
}
