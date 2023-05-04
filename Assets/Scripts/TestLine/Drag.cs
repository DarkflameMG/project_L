using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerUpHandler
{
    // [SerializeField]private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField]private bool isPointer1;
    private bool isStart = false;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log(transform.parent.GetComponent<RectTransform>());
        isStart = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("begin");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("end");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta ;/// canvas.scaleFactor;
        // Debug.Log( rectTransform.anchoredPosition);
    }

    private void Update() {
        if(!isPointer1 && !isStart)
        {
            // transform.position = currentMousePosition();
        }
    }

    private Vector3 currentMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
