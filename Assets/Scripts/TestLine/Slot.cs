using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler,IPointerDownHandler,IBeginDragHandler,IDragHandler
{
    [SerializeField]private Transform linePre;
    private Transform lineParent;
    private void Awake() {
        lineParent = GameObject.Find("Line").transform;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        eventData.pointerDrag.transform.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        // Transform newLine = Instantiate(linePre,Vector3.zero,Quaternion.identity,lineParent);
        // newLine.GetChild(1).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        // newLine.GetChild(2).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Transform newLine = Instantiate(linePre,Vector3.zero,Quaternion.identity,lineParent);
        newLine.GetChild(1).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        newLine.GetChild(2).GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        eventData.pointerDrag = newLine.GetChild(2).gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }
}
