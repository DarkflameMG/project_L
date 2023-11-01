using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMapBtn : MonoBehaviour
{
    [SerializeField]private GameObject gridInitUI;
    private Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(NewMap);
    }

    private void NewMap()
    {   
        gridInitUI.SetActive(true);
    }
}
