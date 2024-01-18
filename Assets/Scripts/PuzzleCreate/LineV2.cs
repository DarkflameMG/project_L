using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineV2 : Line
{
     private bool start = false;
   protected override void PositionUpdate()
   {
        lineRenderer.SetPosition(0,new Vector3(point1.position.x,point1.position.y,1010f));
        lineRenderer.SetPosition(1,new Vector3(point2.position.x,point2.position.y,1010f));
        transform.parent.GetComponent<IPowerLine>().SetState(currentState);
   }

   private void RunLine()
   {
        if(point1.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
        {
            currentState = point1.GetComponent<Drag>().GetCurrentState();
        }
        else if(point2.GetComponent<Drag>().GetSlotNo() == SlotNo.output)
        {
            currentState = point2.GetComponent<Drag>().GetCurrentState();
        }
        ChangeColor();
   }

   public void Run()
   {
     start = true;
   }

   public void StopLine()
   {
        currentState = false;
        ChangeColor();
        start = false;
   }

   protected override void Update()
   {
     PositionUpdate();
     if(start)
     {
          RunLine();
     }
   }
}
