using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Holder : MonoBehaviour, IDropHandler
{
    [SerializeField]private Sprite empty;
    [SerializeField]private Sprite notEmpty;
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
            gate.tag = "Untagged";
            GetComponent<Image>().sprite = notEmpty;
        }
    }

    public void ClearHolded()
    {
        holded = null;
        transform.parent.GetComponent<GateObject>().SetHolded(null);
        GetComponent<Image>().sprite = empty;
    }
}
