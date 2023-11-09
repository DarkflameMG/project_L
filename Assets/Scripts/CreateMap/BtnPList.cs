using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPList : MonoBehaviour
{
    private RoomCatalogSys roomCatalogSys;
    private Button btn;
    private void Awake() {
        roomCatalogSys = GameObject.Find("RoomCatalogSys").GetComponent<RoomCatalogSys>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetCurrentPuzzle);
    }

    private void SetCurrentPuzzle()
    {
        roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().SetCurrentPuzzle(name);
    }
}
