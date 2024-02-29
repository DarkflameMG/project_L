using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2Tone : MonoBehaviour
{
    [SerializeField]private Transform point1;
    [SerializeField]private Transform point2;
    [SerializeField]private bool isLine1;
    private LineRenderer lineRenderer;
    private bool currentState = false;
    private bool isRun = false;
    private Transform input;
    float x1,x2,y1,y2;
    public void RunLine()
    {
        isRun = true;
    }
    private void RunLineAux()
    {
        currentState = input.GetComponent<Drag>().GetCurrentState();
        // Debug.Log(input.GetComponent<Drag>().GetGate().parent.name + " " + currentState);
        transform.parent.GetComponent<PowerLine2>().SetState(currentState);
        ChangeColor();
    }

    public void StopLine()
    {
        currentState = false;
        isRun = false;
        ChangeColor();
    }

    public void LineCreate()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.gray;
        lineRenderer.endColor = Color.gray;
        if(point1.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
        {
            input = point1;
        }
        else if((point2.GetComponent<Drag>().GetSlotNo() == SlotNo.output))
        {
            input = point2;
        }
        else if(point1.GetComponent<Drag>().GetSlotNo() == SlotNo.output2)
        {
            input = point1;
        }
        else if((point2.GetComponent<Drag>().GetSlotNo() == SlotNo.output2))
        {
            input = point2;
        }
    }

    private void ChangeColor()
    {
        if(currentState)
        {
          lineRenderer.startColor = Color.yellow;
          lineRenderer.endColor = Color.yellow;
        }
        else if(!currentState)
        {
          lineRenderer.startColor = Color.gray;
          lineRenderer.endColor = Color.gray;
        }
    }

    private void Update() {
        x1 = point1.position.x;
        x2 = point2.position.x;
        y1 = point1.position.y;
        y2 = point2.position.y;
        lineRenderer.SetPosition(0,new Vector3(x1,y1,1010f));
        lineRenderer.SetPosition(1,new Vector3(x2,y2,1010f));
        if(isRun)
        {
            RunLineAux();
        }
    }
}
