using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
   [SerializeField]private Transform point1;
   [SerializeField]private Transform point2;
   private LineRenderer lineRenderer;
   private bool currentState = false;
   private void Awake() 
   {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
   }
   private void Update() 
   {
        lineRenderer.SetPosition(0,new Vector3(point1.position.x,point1.position.y,1010f));
        lineRenderer.SetPosition(1,new Vector3(point2.position.x,point2.position.y,1010f));
        if(point1.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
        {
               currentState = point1.GetComponent<Drag>().getCurrentState();
        }
        else if(point2.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
        {
               currentState = point2.GetComponent<Drag>().getCurrentState();
        }
        transform.parent.GetComponent<PowerLine>().setState(currentState);
   }

   public bool getCurrentState()
   {
     return currentState;
   }
}
