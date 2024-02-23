using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GateSpawnSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]private LimitGateSys limitGateSys;
    public void OnDrop(PointerEventData eventData)
    {
        Transform gate = eventData.pointerDrag.transform.parent;
        if(eventData.pointerDrag != null && gate.tag == "saveable")
        {
            // eventData.pointerDrag.gameObject.name != "ScrollArea"
            // Debug.Log( eventData.pointerDrag.transform.parent.tag);
            gate.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            string gatename = gate.GetComponent<GateObject>().GetGateName();
            if(limitGateSys != null)
            {
                limitGateSys.IncreaseNumber(gatename);
            }

            if(gate.GetComponent<GateObject>().GetIsHolder() && gate.GetComponent<GateObject>().GetHolded() != null)
            {
                Destroy(gate.GetComponent<GateObject>().GetHolded().gameObject);
            }
            Destroy(gate.gameObject);
        }
    }
}
