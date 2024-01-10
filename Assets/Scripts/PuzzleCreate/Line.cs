using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
   [SerializeField]protected Transform point1;
   [SerializeField]protected Transform point2;
   protected LineRenderer lineRenderer;
   protected bool currentState = false;
   private void Awake() 
   {
      lineRenderer = GetComponent<LineRenderer>();
      lineRenderer.positionCount = 2;
      lineRenderer.startColor = Color.gray;
      lineRenderer.endColor = Color.gray;
   }
   private void Update() 
   {
      PositionUpdate();
   }

  protected virtual void PositionUpdate()
  {
    lineRenderer.SetPosition(0,new Vector3(point1.position.x,point1.position.y,1010f));
    lineRenderer.SetPosition(1,new Vector3(point2.position.x,point2.position.y,1010f));
    if(point1.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
    {
      currentState = point1.GetComponent<Drag>().GetCurrentState();
    }
    else if(point2.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
    {
      currentState = point2.GetComponent<Drag>().GetCurrentState();
    }
    transform.parent.GetComponent<IPowerLine>().SetState(currentState);
    ChangeColor();
  } 

   public void ChangeColor()
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

   public bool GetCurrentState()
   {
     return currentState;
   }
}
