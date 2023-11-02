using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRoomSelect : MonoBehaviour
{
    [SerializeField]private RoomType type;
    private RoomCatalogSys roomCatalogSys;
    private Button btn;
    private void Awake() {
        roomCatalogSys = GameObject.Find("RoomCatalogSys").GetComponent<RoomCatalogSys>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeSlot);
    }

    private void ChangeSlot()
    {
        roomCatalogSys.AddRoom(type);
    }
}
