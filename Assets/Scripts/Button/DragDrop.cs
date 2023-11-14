using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    // [SerializeField]private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform scrollParent;
    private Transform unscrollParent;
    private Transform gate;
    private bool dragable = true;

    private void Awake() {
        rectTransform = transform.parent.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        gate = transform.parent;
        scrollParent = GameObject.Find("spawnGate").transform;
        unscrollParent = GameObject.Find("preSpawnGate").transform;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log(transform.parent.GetComponent<RectTransform>());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("begin");
        if(dragable)
        {
            canvasGroup.blocksRaycasts = false;
            gate.SetParent(unscrollParent);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("end");
        if(dragable)
        {
            canvasGroup.blocksRaycasts = true;
            gate.SetParent(scrollParent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(dragable)
        {
            rectTransform.anchoredPosition += eventData.delta ;/// canvas.scaleFactor;
            // Debug.Log( rectTransform.anchoredPosition);
        }
    }

    public void SetDragable(bool data)
    {
        dragable = data;
    }
}
