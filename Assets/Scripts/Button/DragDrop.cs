using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    // [SerializeField]private Canvas canvas;
    [SerializeField]private GameObject nameTag;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform scrollParent;
    private Transform unscrollParent;
    private Transform gate;
    private bool dragable = true;
    private Canvas canvas;

    private void Awake() {
        rectTransform = transform.parent.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
        gate = transform.parent;
        scrollParent = GameObject.Find("spawnGate").transform;
        // unscrollParent = GameObject.Find("preSpawnGate").transform;
        // unscrollParent = transform.parent.GetComponent<GateObject>().GetPreSpawnPoint();
        // Debug.Log(unscrollParent);
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log(transform.parent.GetComponent<RectTransform>());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log(unscrollParent.name);
        // Debug.Log(transform.parent.name);
        
        OnBeginDragAux();
    }

    public void OnBeginDragAux()
    {
        unscrollParent = transform.parent.GetComponent<GateObject>().GetPreSpawnPoint();
        if(dragable)
        {
            if(nameTag != null)
            {
                nameTag.SetActive(true);
            }
            Transform holder = gate.GetComponent<GateObject>().GetHolder();
            canvasGroup.blocksRaycasts = false;
            gate.SetParent(unscrollParent);
            if(holder != null)
            {
                holder.GetChild(0).GetComponent<Holder>().ClearHolded();
                transform.parent.tag = "saveable";
            }
            gate.GetComponent<GateObject>().SetHolder(null);
            gate.GetComponent<GateObject>().UnHideSlot();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("end");
        if(dragable)
        {
            if(nameTag != null)
            {
                nameTag.SetActive(false);
            }
            canvasGroup.blocksRaycasts = true;
            gate.SetParent(scrollParent);
            if(gate.GetComponent<GateObject>().GetIsHolder())
            {
                gate.SetAsFirstSibling();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(dragable)
        {
            rectTransform.anchoredPosition += eventData.delta ;/// canvas.scaleFactor;
            //  rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            // Debug.Log( rectTransform.anchoredPosition);
        }
    }

    public void SetDragable(bool data)
    {
        dragable = data;
    }
}
