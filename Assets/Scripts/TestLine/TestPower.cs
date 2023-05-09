using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestPower : MonoBehaviour, IPointerDownHandler
{
    private  GateObject parentGate;
    private void Awake() {
        parentGate = transform.parent.GetComponent<GateObject>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("power : 0");
        Debug.Log(parentGate.GetGateSO().gateName+" : "+parentGate.getCurrentState());
    }
}
