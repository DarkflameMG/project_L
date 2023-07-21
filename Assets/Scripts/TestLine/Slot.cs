using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler,IPointerDownHandler,IBeginDragHandler,IDragHandler
{
    [SerializeField]private Transform linePre;
    [SerializeField]private SlotNo slotNo;
    private Transform lineParent;
    private Transform currentLine;
    private void Awake() {
        lineParent = GameObject.Find("spawnLine").transform;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        if(eventData.pointerDrag != null && currentLine == null)
        {
            Vector2 parentPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+parentPosition;
            eventData.pointerDrag.transform.GetComponent<Drag>().setValid(this.transform);
            currentLine = eventData.pointerDrag.transform.parent;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(currentLine);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(currentLine == null)
        {
            Vector2 parentPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
            // Debug.Log(parentPosition);
            Transform newLine = Instantiate(linePre,Vector3.zero,Quaternion.identity,lineParent);
            newLine.GetChild(1).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+parentPosition;
            newLine.GetChild(2).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+parentPosition;
            eventData.pointerDrag = newLine.GetChild(2).gameObject;
            currentLine = newLine;
            newLine.GetChild(1).GetComponent<Drag>().setValid(this.transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void slotFree()
    {
        currentLine = null;
    }

    private void Update() {
        if(currentLine != null)
        {
            bool input = currentLine.GetComponent<PowerLine>().getCurrentState();
            if(slotNo == SlotNo.s1)
            {
                transform.parent.GetComponent<GateObject>().SetSlot1(input);
            }
            else if(slotNo == SlotNo.s2)
            {
                transform.parent.GetComponent<GateObject>().SetSlot2(input);
            }
        }
        else
        {
            transform.parent.GetComponent<GateObject>().SetSlot1(false);
            transform.parent.GetComponent<GateObject>().SetSlot2(false);
        }
    }

    public bool getCurrentState()
    {
        return transform.parent.GetComponent<GateObject>().getCurrentState();
    }

    public SlotNo getSlotType()
    {
        return slotNo;
    }

    public void setLine(Transform line)
    {
        currentLine = line;
    }
}

