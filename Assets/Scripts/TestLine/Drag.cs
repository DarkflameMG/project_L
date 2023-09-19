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
        Debug.Log(SlotPosition());
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("up");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("begin");
        // if(dragable)
        // {
        //     canvasGroup.blocksRaycasts = false;
        //     isValid = false;
        //     currentSlot.GetComponent<Slot>().SlotFree();
        //     currentSlot = null;
        // }
        OnBeginDragAux();
    }

    public void OnBeginDragAux()
    {
        if(dragable)
        {
            canvasGroup.blocksRaycasts = false;
            isValid = false;
            currentSlot.GetComponent<Slot>().SlotFree();
            currentSlot = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
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

    public void SetValid(Transform slot){
        isValid = true;
        currentSlot = slot;
    }

    public void SetSlotPuzzle(Transform slot)
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
            GetComponent<RectTransform>().anchoredPosition = SlotPosition();
        }
    }

    private Vector2 SlotPosition()
    {
        Vector2 parentSlotPosition = currentSlot.parent.GetComponent<RectTransform>().anchoredPosition;
        Vector2 currentSlotPostion = currentSlot.GetComponent<RectTransform>().anchoredPosition;
        return parentSlotPosition+currentSlotPostion;
    }
    public bool GetCurrentState()
    {
        return currentSlot.GetComponent<Slot>().GetCurrentState();
    }
    public SlotNo GetSlotNo()
    {
        return currentSlot.GetComponent<Slot>().GetSlotType();
    }

    public Transform GetGate()
    {
        return currentSlot;
    }

    public void SetDragable(bool data)
    {
        dragable = data;
    }

    public bool PoiterNo()
    {
        return isPointer1;
    }
}
