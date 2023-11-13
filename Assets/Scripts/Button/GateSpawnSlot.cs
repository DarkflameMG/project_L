using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GateSpawnSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.gameObject.name != "ScrollArea")
        {
            // Debug.Log( eventData.pointerDrag.transform.parent);
            eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Destroy(eventData.pointerDrag.transform.parent.gameObject);
        }
    }
}
