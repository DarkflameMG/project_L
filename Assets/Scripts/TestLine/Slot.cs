using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler,IPointerDownHandler,IBeginDragHandler,IDragHandler
{
    [SerializeField]private Transform linePre;
    private Transform lineParent;
    private Transform currentLine;
    private void Awake() {
        lineParent = GameObject.Find("spawnLine").transform;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        if(eventData.pointerDrag != null)
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
}
