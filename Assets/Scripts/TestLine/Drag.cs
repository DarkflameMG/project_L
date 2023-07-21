using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerUpHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField]private bool isPointer1;
    private bool isValid = false;
    private Transform currentSlot;
    private bool dragable = true;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(slotPosition());
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("up");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("begin");
        if(dragable)
        {
            canvasGroup.blocksRaycasts = false;
            isValid = false;
            currentSlot.GetComponent<Slot>().slotFree();
            currentSlot = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("end");
        if(dragable)
        {
            canvasGroup.blocksRaycasts = true;
            if(!isValid)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(dragable)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        // Debug.Log( rectTransform.anchoredPosition);
    }

    public void setValid(Transform slot){
        isValid = true;
        currentSlot = slot;
    }

    public void setSlotPuzzle(Transform slot)
    {
        currentSlot = slot;
    }

    private void Update() {
        if(isValid && currentSlot == null)
        {
            Destroy(transform.parent.gameObject);
        }

        else if(isValid)
        {
            GetComponent<RectTransform>().anchoredPosition = slotPosition();
        }
    }

    private Vector2 slotPosition()
    {
        Vector2 parentSlotPosition = currentSlot.parent.GetComponent<RectTransform>().anchoredPosition;
        Vector2 currentSlotPostion = currentSlot.GetComponent<RectTransform>().anchoredPosition;
        return parentSlotPosition+currentSlotPostion;
    }
    public bool getCurrentState()
    {
        return currentSlot.GetComponent<Slot>().getCurrentState();
    }
    public SlotNo GetSlotNo()
    {
        return currentSlot.GetComponent<Slot>().getSlotType();
    }

    public Transform getGate()
    {
        return currentSlot;
    }

    public void setDragable(bool data)
    {
        dragable = data;
    }
}
