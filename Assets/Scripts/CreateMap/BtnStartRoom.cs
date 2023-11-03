using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnStartRoom : MonoBehaviour
{
    private RoomCatalogSys roomCatalogSys;
    private Button btn;
    private void Awake() {
        roomCatalogSys = GameObject.Find("RoomCatalogSys").GetComponent<RoomCatalogSys>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetStartRoom);
    }

    private void SetStartRoom()
    {
        roomCatalogSys.AddStartRoom();
    }
}
