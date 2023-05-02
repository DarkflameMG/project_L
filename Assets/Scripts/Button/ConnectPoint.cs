using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConnectPoint : MonoBehaviour, IPointerClickHandler,IPointerDownHandler,IDragHandler,IDropHandler,IEndDragHandler
{
    private LineRenderer lineRenderer;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    private bool haveLine = false;
    private Transform connectGatePoint;
    private Transform lineParent;
    private bool haveSlot = false;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineParent = GameObject.Find("spawnLine").transform;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CP click");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log();
        mousePos = currentMousePosition();
        lineRenderer.SetPosition(0,new Vector3(startMousePos.x,startMousePos.y,0f));
        lineRenderer.SetPosition(1,new Vector3(mousePos.x,mousePos.y,0f));
        haveSlot = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        haveLine = true;
        if(!haveSlot)
        {
            deleteLine();
            haveLine = false;
            lineRenderer.SetPosition(0,Vector3.zero);
            lineRenderer.SetPosition(1,Vector3.zero);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("drop");
        // Debug.Log(eventData.pointerDrag);
        // connectGatePoint = eventData.pointerDrag.transform;
        // Debug.Log(connectGatePoint.position);
        eventData.pointerDrag.GetComponent<ConnectPoint>().setEndPoint();
    }

    [SerializeField]private Transform linePrefab;

    private LineController currentLine;
    private Vector3 currentMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointerDown");
        startMousePos = currentMousePosition();

        if(currentLine == null)
        {
            currentLine = Instantiate(linePrefab,Vector3.zero,Quaternion.identity,lineParent).GetComponent<LineController>();
        }
        currentLine.AddPoint(transform);
    }

    private void Update() {
        if(haveLine)
        {
            lineRenderer.SetPosition(0,new Vector3(transform.position.x,transform.position.y,0f));
            // lineRenderer.SetPosition(1,new Vector3(connectGatePoint.position.x,connectGatePoint.position.y,0f));
        }
    }

    public void setEndPoint()
    {
        lineRenderer.SetPosition(1,new Vector3(transform.position.x,transform.position.y,0f));
        haveSlot =true;
    }

    public void deleteLine()
    {
        Destroy(currentLine.gameObject);
    }
}
