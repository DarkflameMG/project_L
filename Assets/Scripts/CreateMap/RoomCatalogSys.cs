using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCatalogSys : MonoBehaviour
{
    [SerializeField]private GameObject catalogUI;
    [SerializeField]private RoomPreviewSO allRoom;
    private Transform currentSlot;
    public void ShowUI(Transform slot)
    {
        catalogUI.SetActive(true);
        SetCurerntSlot(slot);
    }

    public void CloseUI()
    {
        catalogUI.SetActive(false);
    }

    private void SetCurerntSlot(Transform slot)
    {
        currentSlot = slot;
        catalogUI.GetComponent<RectTransform>().localPosition = slot.GetComponent<RectTransform>().localPosition + slot.parent.GetComponent<RectTransform>().localPosition + new Vector3(105f,0,0);
    }

    public void AddRoom(RoomType type)
    {
        Image img = currentSlot.GetChild(0).GetComponent<Image>();
        if(type == RoomType.defalut)
        {
            img.sprite = allRoom.defalut;
        }
        else if(type == RoomType.room1)
        {
            img.sprite = allRoom.room1;
        }
    }
}
