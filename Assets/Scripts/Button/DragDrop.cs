using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    // [SerializeField]private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool dragable = true;

    private void Awake() {
        rectTransform = transform.parent.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
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
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("end");
        if(dragable)
        {
            canvasGroup.blocksRaycasts = true;
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

    public void setDragable(bool data)
    {
        dragable = data;
    }
}
