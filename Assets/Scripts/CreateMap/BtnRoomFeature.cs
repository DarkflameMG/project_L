using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRoomFeature : MonoBehaviour
{
    [SerializeField]private FeatureType featureType;
    [SerializeField]private Transform roomCatalogSys;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AddFeature);
    }

    private void AddFeature()
    {
        roomCatalogSys.GetComponent<RoomCatalogSys>().AddRoomFeature(featureType);
    }
}
