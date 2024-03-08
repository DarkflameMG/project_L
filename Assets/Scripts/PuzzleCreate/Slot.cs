using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler,IPointerDownHandler,IBeginDragHandler,IDragHandler
{
    [SerializeField]private Transform linePre;
    [SerializeField]private SlotNo slotNo;
    private Transform lineParent;
    private Transform currentLine;
    private bool isPointer1 = false;
    private UnityEngine.UI.Image image;
    private void Awake() {
        if(GameObject.Find("spawnLine") != null)
        {
            lineParent = GameObject.Find("spawnLine").transform;
        }
        image = GetComponent<UnityEngine.UI.Image>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        if(eventData.pointerDrag != null && currentLine == null)
        {
            Vector2 parentPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+parentPosition;
            eventData.pointerDrag.transform.GetComponent<Drag>().SetValid(this.transform);
            isPointer1 = eventData.pointerDrag.transform.GetComponent<Drag>().PoiterNo();
            currentLine = eventData.pointerDrag.transform.parent;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log(currentLine);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(currentLine == null)
        {
            Vector2 parentPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            // Debug.Log(parentPosition);
            Transform newLine = Instantiate(linePre,Vector3.zero,Quaternion.identity,lineParent);
            newLine.GetComponent<Transform>().localPosition = Vector3.zero;
            newLine.GetChild(1).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+parentPosition;
            newLine.GetChild(2).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+parentPosition;
            eventData.pointerDrag = newLine.GetChild(2).gameObject;
            currentLine = newLine;
            newLine.GetChild(1).GetComponent<Drag>().SetValid(this.transform);
            isPointer1 = true;
        }
        else
        {
            if(isPointer1)
            {
                eventData.pointerDrag = currentLine.GetChild(1).gameObject;
                currentLine.GetChild(1).GetComponent<Drag>().OnBeginDragAux();
            }
            else
            {
                eventData.pointerDrag = currentLine.GetChild(2).gameObject;
                currentLine.GetChild(2).GetComponent<Drag>().OnBeginDragAux();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void SlotFree()
    {
        currentLine = null;
    }

    private void Update() {
        if(currentLine != null)
        {
            bool input = currentLine.GetComponent<IPowerLine>().GetCurrentState();
            if(slotNo == SlotNo.s1)
            {
                transform.parent.GetComponent<GateObject>().SetSlot1(input);
            }
            else if(slotNo == SlotNo.s2)
            {
                transform.parent.GetComponent<GateObject>().SetSlot2(input);
            }
            image.color = new Color32(255,128,0,255);
        }
        else
        {
            transform.parent.GetComponent<GateObject>().SetSlot1(false);
            transform.parent.GetComponent<GateObject>().SetSlot2(false);
            image.color = new Color32(47,255,0,255);
        }
    }

    public bool GetCurrentState()
    {
        return transform.parent.GetComponent<GateObject>().GetCurrentState();
    }

    public SlotNo GetSlotType()
    {
        return slotNo;
    }

    public void SetLine(Transform line)
    {
        currentLine = line;
    }

    public Transform GetCurrentLine()
    {
        return currentLine;
    }
}

