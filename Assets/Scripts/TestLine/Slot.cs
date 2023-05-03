using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler,IPointerDownHandler
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
        Instantiate(linePre,Vector3.zero,Quaternion.identity,lineParent);
    }
}
