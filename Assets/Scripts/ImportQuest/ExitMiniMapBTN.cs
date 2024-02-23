using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMiniMapBTN : MonoBehaviour
{
    [SerializeField]MiniMapSys miniMapSys;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ToggleMap);
    }

    private void ToggleMap()
    {
        miniMapSys.ToggleMap();
    }
}
