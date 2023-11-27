using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Holder : MonoBehaviour, IDropHandler
{
    private Transform holded;
    public void OnDrop(PointerEventData eventData)
    {
        Transform gate = eventData.pointerDrag.transform.parent;
        if(eventData.pointerDrag != null && !gate.GetComponent<GateObject>().GetIsHolder() && holded == null)
        {
            gate.GetComponent<RectTransform>().anchoredPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            gate.GetComponent<GateObject>().SetHolder(transform.parent);
            gate.GetComponent<GateObject>().HideSlot();
            holded = gate;
            transform.parent.GetComponent<GateObject>().SetHolded(holded);
            transform.parent.SetAsFirstSibling();
        }
    }

    public void ClearHolded()
    {
        holded = null;
        transform.parent.GetComponent<GateObject>().SetHolded(null);
    }
}
