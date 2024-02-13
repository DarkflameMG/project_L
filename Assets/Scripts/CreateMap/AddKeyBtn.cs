using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddKeyBtn : MonoBehaviour
{
    [SerializeField]private AddDoorKeySys addDoorKeySys;
    [SerializeField]private RoomSide side;
    Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetKey);
    }

    private void SetKey()
    {
        addDoorKeySys.OpenKeyList(side);
    }
}
