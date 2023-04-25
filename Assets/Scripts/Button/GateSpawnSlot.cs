using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GateSpawnSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        if(eventData.pointerDrag != null)
        {
            // Debug.Log( eventData.pointerDrag.transform.parent);
            eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Destroy(eventData.pointerDrag.transform.parent.gameObject);
        }
    }
}
