using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Holder : MonoBehaviour, IDropHandler
{
    private Transform holded;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && !eventData.pointerDrag.transform.parent.GetComponent<GateObject>().GetIsHolder())
        {
            eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().anchoredPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.parent.GetComponent<GateObject>().SetHolder(transform.parent);
            SetChildDragable( eventData.pointerDrag.transform.parent);
            transform.parent.SetAsFirstSibling();
        }
    }

    private void SetChildDragable(Transform parent)
    {
        Debug.Log("start");
        Transform s1 = parent.Find("s1");
        Transform s2 = parent.Find("s2");
        Transform output = parent.Find("output");
        if(s1 != null)
        {
            s1.gameObject.SetActive(false);
        }

        if(s2 != null)
        {
            s2.gameObject.SetActive(false);
        }

        if(output != null)
        {
            output.gameObject.SetActive(false);
        }
    }
}
